using System.Collections;
using UnityEngine;

public class CookieRunAI : MonoBehaviour
{
    private bool _isActivePlayer;

    private void Start()
    {
        Debug.Log("CookieRunAI::Start");

        _isActivePlayer = false;
        if (RulesEngine.Instance == null)
        {
            RulesEngine.OnInstanceReady += SubscribeToEvents;
        }
        else
        {
            SubscribeToEvents();
        }
    }

    private void OnDestroy()
    {
        Debug.Log("CookieRunAI::OnDestroy");
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        Debug.Log("CookieRunAI::SubscribeToEvents");

        if (RulesEngine.Instance == null)
        {
            return;
        }

        RulesEngine.Instance.MulligansStartEvent += RulesEngine_MulligansStartEvent;
        RulesEngine.Instance.PreGameCookiePlacementEvent += RulesEngine_PreGameCookiePlacementEvent;
        RulesEngine.Instance.NewActivePlayerEvent += RulesEngine_NewActivePlayerEvent;
        RulesEngine.Instance.PlayerEnterGamePhaseEvent += RulesEngine_PlayerPlayerEnterGamePhaseEvent;
    }

    private void UnsubscribeFromEvents()
    {
        Debug.Log("CookieRunAI::UnsubscribeFromEvents");

        if (RulesEngine.Instance == null)
        {
            return;
        }
        
        RulesEngine.Instance.MulligansStartEvent -= RulesEngine_MulligansStartEvent;
        RulesEngine.Instance.PreGameCookiePlacementEvent -= RulesEngine_PreGameCookiePlacementEvent;
        RulesEngine.Instance.NewActivePlayerEvent -= RulesEngine_NewActivePlayerEvent;
        RulesEngine.Instance.PlayerEnterGamePhaseEvent -= RulesEngine_PlayerPlayerEnterGamePhaseEvent;
    }

    private void RulesEngine_MulligansStartEvent()
    {
        Debug.Log("CookieRunAI::RulesEngine_MulligansStartEvent");
        StartCoroutine(HandleMulliganDecision());
    }

    private void RulesEngine_PreGameCookiePlacementEvent()
    {
        Debug.Log("CookieRunAI::RulesEngine_PreGameCookiePlacementEvent");
        StartCoroutine(HandlePreGameCookiePlacementDecision());
    }

    private void RulesEngine_NewActivePlayerEvent(ulong playerId)
    {
        Debug.Log("CookieRunAI::RulesEngine_NewActivePlayerEvent");
        _isActivePlayer = playerId == CookieRunConstants.BOT_PLAYER_ID;
    }

    private void RulesEngine_PlayerPlayerEnterGamePhaseEvent(ulong playerId, GamePhase phase)
    {
        Debug.Log("CookieRunAI::RulesEngine_PlayerPlayerEnterGamePhaseEvent");

        switch (phase)
        {
            case GamePhase.Battle:
            case GamePhase.Active:
            case GamePhase.Draw:
            case GamePhase.End:
            case GamePhase.Setup:
                break;
            case GamePhase.Support:
                if (playerId == CookieRunConstants.BOT_PLAYER_ID)
                {
                    StartCoroutine(HandleSupportPhaseDecision());
                }
                break;
            case GamePhase.Main:
                if (playerId == CookieRunConstants.BOT_PLAYER_ID)
                {
                    StartCoroutine(HandleMainPhaseDecision());
                }
                break;
            default:
                Debug.Log($"{phase} is not a valid Game Phase");
                break;
        }
    }

    private IEnumerator HandleMulliganDecision()
    {
        Debug.Log("CookieRunAI::HandleMulliganDecision");

        yield return new WaitForSeconds(5f);

        bool shouldMulligan = Random.Range(0, 2) == 0;
        if (shouldMulligan)
        {
            Debug.Log("CookieRunAI::HandleMulliganDecision - Requesting mulligan");
            RulesEngine.Instance.GetGameStateManager().HandleMulliganRequestForPlayer(CookieRunConstants.BOT_PLAYER_ID);
        }
        else
        {
            Debug.Log("CookieRunAI::HandleMulliganDecision - Refusing mulligan");
            RulesEngine.Instance.GetGameStateManager().HandleMulliganRefusalForPlayer(CookieRunConstants.BOT_PLAYER_ID);
        }
    }

    private IEnumerator HandlePreGameCookiePlacementDecision()
    {
        Debug.Log("CookieRunAI::HandlePreGameCookiePlacementDecision");

        yield return new WaitForSeconds(2f);

        HandleRandomHandCardClick();
    }

    private IEnumerator HandleSupportPhaseDecision()
    {
        Debug.Log("CookieRunAI::HandleSupportPhaseDecision");
        yield return new WaitForSeconds(1f);

        bool shouldSkipSupport = Random.Range(0, 2) == 0;
        if (shouldSkipSupport)
        {
            Debug.Log("CookieRunAI::HandleSupportPhaseDecision - Skipping support phase");
            RulesEngine.Instance.GetGameStateManager().SkipSupport(CookieRunConstants.BOT_PLAYER_ID);
        }
        else
        {
            Debug.Log("CookieRunAI::HandleSupportPhaseDecision - Playing a card");
            HandleRandomHandCardClick();
        }
    }

    private IEnumerator HandleMainPhaseDecision()
    {
        Debug.Log("CookieRunAI::HandleMainPhaseDecision");
        yield return new WaitForSeconds(1f);

        //bool shouldEndTurn = Random.Range(0, 2) == 0;
        //if (shouldEndTurn)
        //{
            Debug.Log("CookieRunAI::HandleMainPhaseDecision - Ending turn");
            RulesEngine.Instance.GetGameStateManager().EndTurn(CookieRunConstants.BOT_PLAYER_ID);
        //}
        //else
        //{
        //    Debug.Log("CookieRunAI::HandleMainPhaseDecision - Playing a card");
        //    HandleRandomHandCardClick();
        //}
    }

    private void HandleRandomHandCardClick()
    {
        Debug.Log("CookieRunAI::HandleRandomHandCardClick");

        var handCards = RulesEngine.Instance.GetGameZoneManager().GetCardsInZone(CookieRunConstants.BOT_PLAYER_ID, GameZoneType.Hand);

        if (handCards.Count > 0)
        {
            int randomIndex = Random.Range(0, handCards.Count);
            int chosenCardMatchId = handCards[randomIndex];

            Debug.Log($"CookieRunAI::HandleRandomHandCardClick - Chose card with ID: {chosenCardMatchId}");

            RulesEngine.Instance.GetGameStateManager().HandleCardClickedForPlayer(CookieRunConstants.BOT_PLAYER_ID, chosenCardMatchId);
        }
        else
        {
            Debug.LogWarning("CookieRunAI::HandleRandomHandCardClick - No cards in hand to play");
        }
    }
}