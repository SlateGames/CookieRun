using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.Services.Matchmaker;
using Unity.Services.Matchmaker.Models;
using UnityEngine;

//TODO: For the ranked queue, implement matchmaking rules based on the leaderboard? Then I could just use the leaderboard instead of Elo (or with it, whatever). https://docs.unity.com/ugs/manual/matchmaker/manual/matchmaking-rules-rules

//TODO: Should this be in a transition or loading screen? Like, the flow goes:
//Main menu
//Player clicks button
//Player moves to matchmaking scene
//Match is found
//Match is validated
//Player moves to new scene
//I want this class to handle the match validation. Maybe move this code to UCC?

namespace Matchplay.Client
{
    public enum MatchmakerPollingResult
    {
        Success,
        TicketCreationError,
        TicketCancellationError,
        TicketRetrievalError,
        MatchAssignmentError
    }

    public class MatchmakingResult
    {
        public string ip;
        public int port;
        public MatchmakerPollingResult result;
        public string resultMessage;
    }

    public class MatchplayMatchmaker : IDisposable
    {
        private static MatchplayMatchmaker _instance;
        public static MatchplayMatchmaker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MatchplayMatchmaker();
                }
                return _instance;
            }
        }

        public event Action<string> OnMatchmakingStatusChanged;
        private MultiplayAssignment.StatusOptions m_LastKnownStatus = MultiplayAssignment.StatusOptions.Found;

        string m_LastUsedTicket;
        bool m_IsMatchmaking = false;

        CancellationTokenSource m_CancelToken;
        const int k_GetTicketCooldown = 1000;

        /// <summary>
        /// Create a ticket for the one user and begin matchmaking with their preferences
        /// </summary>
        /// <param name="data">The Client's preferences and ID</param>
        public async Task<MatchmakingResult> Matchmake(UserData data)
        {
            Debug.Log("MatchplayMatchmaker::Matchmake");

            m_CancelToken = new CancellationTokenSource();
            var createTicketOptions = UserDataToTicketRuleOptions(data);
            var players = new List<Player> { new Player(data.userAuthId, new Dictionary<string, object> { { "WinCount", data.winCount }, { "Elo", data.elo } }) };
            try
            {
                m_IsMatchmaking = true;
                var createResult = await MatchmakerService.Instance.CreateTicketAsync(players, createTicketOptions);

                m_LastUsedTicket = createResult.Id;
                try
                {
                    int queryCount = 0;
                    //Polling Loop, cancelling should take us all the way to the method
                    while (!m_CancelToken.IsCancellationRequested)
                    {
                        var checkTicket = await MatchmakerService.Instance.GetTicketAsync(m_LastUsedTicket);

                        if (checkTicket.Type == typeof(MultiplayAssignment))
                        {
                            var matchAssignment = (MultiplayAssignment)checkTicket.Value;

                            if (matchAssignment.Status == MultiplayAssignment.StatusOptions.Found)
                            {
                                return ReturnMatchResult(MatchmakerPollingResult.Success, "", matchAssignment);
                            }
                            if (matchAssignment.Status == MultiplayAssignment.StatusOptions.Timeout)
                            {
                                Debug.LogWarning("Matchmaking timed out. No longer in queue.");
                                return ReturnMatchResult(MatchmakerPollingResult.MatchAssignmentError, $"Ticket: {m_LastUsedTicket} - {matchAssignment.Status} - {matchAssignment.Message}");
                            }
                            if (matchAssignment.Status == MultiplayAssignment.StatusOptions.Failed)
                            {
                                Debug.LogWarning("Matchmaking encountered an error. No longer in queue.");
                                return ReturnMatchResult(MatchmakerPollingResult.MatchAssignmentError, $"Ticket: {m_LastUsedTicket} - {matchAssignment.Status} - {matchAssignment.Message}");
                            }

                            queryCount++;
                            Debug.Log("Ticket ID: " + m_LastUsedTicket + Environment.NewLine + "Status: " + matchAssignment.Status + Environment.NewLine + "Query Count: " + queryCount);
                            Debug.Log($"Polled Ticket: {m_LastUsedTicket} Status: {matchAssignment.Status} ");

                            if (matchAssignment.Status != m_LastKnownStatus)
                            {
                                m_LastKnownStatus = matchAssignment.Status;
                                OnMatchmakingStatusChanged?.Invoke("Ticket ID: " + m_LastUsedTicket + Environment.NewLine + "Status: " + matchAssignment.Status);
                            }
                        }

                        await Task.Delay(k_GetTicketCooldown);
                    }
                }
                catch (MatchmakerServiceException e)
                {
                    return ReturnMatchResult(MatchmakerPollingResult.TicketRetrievalError, e.ToString());
                }
            }
            catch (MatchmakerServiceException e)
            {
                return ReturnMatchResult(MatchmakerPollingResult.TicketCreationError, e.ToString());
            }

            m_LastKnownStatus = MultiplayAssignment.StatusOptions.Failed;
            Debug.Log("Matchmaking was cancelled. No longer in queue.");
            return ReturnMatchResult(MatchmakerPollingResult.TicketCancellationError, "Cancelled Matchmaking");
        }

        public bool IsMatchmaking => m_IsMatchmaking;

        public async Task CancelMatchmaking()
        {
            Debug.Log("MatchplayMatchmaker::CancelMatchmaking");

            if (!m_IsMatchmaking)
            {
                return;
            }

            m_IsMatchmaking = false;
            if (m_CancelToken.Token.CanBeCanceled)
            {
                m_CancelToken.Cancel();
            }

            if (string.IsNullOrEmpty(m_LastUsedTicket))
            {
                return;
            }

            Debug.Log($"Cancelling {m_LastUsedTicket}");
            await MatchmakerService.Instance.DeleteTicketAsync(m_LastUsedTicket);
        }

        //Make sure we exit the matchmaking cycle through this method every time.
        MatchmakingResult ReturnMatchResult(MatchmakerPollingResult resultErrorType, string message = "", MultiplayAssignment assignment = null)
        {
            Debug.Log("MatchplayMatchmaker::ReturnMatchResult");

            m_IsMatchmaking = false;

            if (assignment != null)
            {
                var parsedIP = assignment.Ip;
                var parsedPort = assignment.Port;
                if (parsedPort == null)
                {
                    return new MatchmakingResult
                    {
                        result = MatchmakerPollingResult.MatchAssignmentError,
                        resultMessage = $"Port missing? - {assignment.Port}\n-{assignment.Message}"
                    };
                }

                return new MatchmakingResult
                {
                    result = MatchmakerPollingResult.Success,
                    ip = parsedIP,
                    port = (int)parsedPort,
                    resultMessage = assignment.Message
                };
            }

            return new MatchmakingResult
            {
                result = resultErrorType,
                resultMessage = message
            };
        }

        /// <summary>
        /// From Game player to matchmaking player
        /// </summary>
        static CreateTicketOptions UserDataToTicketRuleOptions(UserData data)
        {
            Debug.Log("MatchplayMatchmaker::UserDataToTicketRuleOptions");

            var queueName = data.userGamePreferences.ToMultiplayQueue();
            return new CreateTicketOptions(queueName);
        }

        public void Dispose()
        {
            Debug.Log("MatchplayMatchmaker::Dispose");

#pragma warning disable 4014
            CancelMatchmaking();
#pragma warning restore 4014
            m_CancelToken?.Dispose();
        }
    }
}