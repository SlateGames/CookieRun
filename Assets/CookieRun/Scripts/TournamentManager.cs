using Matchplay.Client;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TournamentManager : MonoBehaviour
{
    //TODO: Make a DebugData class that has stuff like the AuthID
    public static TournamentManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public async Task JoinTournamentQueue(UserData userData)
    {
        Debug.Log("TournamentManager::JoinTournamentQueue");

        switch (userData.userGamePreferences.gameQueue)
        {
            case GameQueue.Singleplayer:
                SceneManager.LoadSceneAsync("GameBoard");
                break;
            case GameQueue.Competitive:
                await LoadCompetitive(userData);
                break;
            case GameQueue.LocalHost:
                SceneManager.LoadSceneAsync("GameBoard");
                break;
            case GameQueue.LocalClient:
                ConnectToLocalMatch();
                break;
        }

    }

    private async Task LoadCompetitive(UserData userData)
    {
        Debug.Log("Joining tournament queue...");

        MatchmakingResult result = await MatchplayMatchmaker.Instance.Matchmake(userData);

        if (result.result == MatchmakerPollingResult.Success)
        {
            Debug.Log($"Match found! Connecting to IP: {result.ip}, Port: {result.port}");
            ConnectToMatch(result.ip, result.port);
        }
        else
        {
            Debug.LogError($"Failed to join tournament queue: {result.resultMessage}");
            HandleMatchmakingFailure(result.resultMessage);
        }
    }

    public async Task LeaveMatchmakingQueue()
    {
        Debug.Log("TournamentManager::LeaveMatchmakingQueue");
        await MatchplayMatchmaker.Instance.CancelMatchmaking();
    }

    private void ConnectToLocalMatch(string ip = "127.0.0.1", int port = 7777)
    {
        ConnectToMatch(ip, port);
    }

    private void ConnectToMatch(string ip, int port)
    {
        Debug.Log("TournamentManager::ConnectToMatch");
        Debug.Log($"Connecting to game server at {ip}:{port}...");

        ClientStorageManager.Instance.ConnectionDataStorageManager.SaveConnectionDetails(ip, port);
        SceneManager.LoadSceneAsync("GameBoard");
    }
 
    private void HandleMatchmakingFailure(string errorMessage)
    {
        Debug.Log("TournamentManager::HandleMatchmakingFailure");
        Debug.LogError("Matchmaking error: " + errorMessage);
    }
}