using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameState_Setup : GameState_Base
{
    private SetupPhase _subPhase;
    private int _postMulliganPlayerCount;
    private int _registeredDeckCount;

    public override void Enter()
    {
        _gamePhase = GamePhase.Setup;
        _subPhase = SetupPhase.GamePreparation;

        RulesEngine.Instance.DeckRegisteredForPlayerEvent += RulesEngine_DeckRegisteredForPlayerEvent;

        _registeredDeckCount = 0;

        MonitorDeckRegistration();

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void RulesEngine_DeckRegisteredForPlayerEvent(DeckDataPayload deckPayload)
    {
        _registeredDeckCount++;
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.LogError("Cannot pass priority during setup phase");
    }

    public void AdvanceSetupPhase()
    {
        switch (_subPhase)
        {
            case SetupPhase.GamePreparation:
                _subPhase = SetupPhase.Mulligans;
                StartMulligans();
                break;
            case SetupPhase.Mulligans:
                _subPhase = SetupPhase.PreGameCookiePlacement;
                break;
            case SetupPhase.PreGameCookiePlacement:
                RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Active());
                break;
            default:
                Debug.LogError($"Unknown setup phase: {_subPhase}");
                return;
        }
    }

    public SetupPhase GetSetupSubPhase()
    {
        return _subPhase;
    }

    private async Task MonitorDeckRegistration()
    {
        Debug.Log("GameStateManager::MonitorDeckRegistration");

        while (true)
        {
            if (_registeredDeckCount >= 2)
            {
                RegisterMatch();
                AdvanceSetupPhase();

                break;
            }

            await Task.Delay(500);
        }
    }

    public void StartMulligans()
    {
        Debug.Log("GameStateManager::StartMulligans");

        //TODO: Need to setup auto mulligans for after the player has made their choice. Also set it up so that they are forced to mulligan if they have no cookies the first time. 
        ulong player1Id = RulesEngine.Instance.GetGameStateManager().Player1Id;
        ulong player2Id = RulesEngine.Instance.GetGameStateManager().Player2Id;

        RulesEngine.Instance.GetGameZoneManager().ShuffleDeckForPlayer(player1Id);
        RulesEngine.Instance.GetGameZoneManager().DrawCards(player1Id, 6, RulesEngine.GAME_ACTION);

        RulesEngine.Instance.GetGameZoneManager().ShuffleDeckForPlayer(player2Id);
        RulesEngine.Instance.GetGameZoneManager().DrawCards(player2Id, 6, RulesEngine.GAME_ACTION);

        RulesEngine.Instance.BroadcastMulligansStartEvent();

    }

    public void PlayerRefusesMulligan(ulong playerId)
    {
        Debug.Log("GameStateManager::PlayerRefusesMulligan");

        _postMulliganPlayerCount++;
        if (_postMulliganPlayerCount >= 2)
        {
            EndMulligan();
        }
    }

    public void PlayerRequestsMulligan(ulong playerId)
    {
        Debug.Log("GameStateManager::PlayerRequestsMulligan");

        RulesEngine.Instance.GetGameZoneManager().MulliganCardsForPlayer(playerId);

        _postMulliganPlayerCount++;
        if (_postMulliganPlayerCount >= 2)
        {
            EndMulligan();
        }
    }

    public void EndMulligan()
    {
        Debug.Log("GameStateManager::EndMulligan");

        RulesEngine.Instance.BroadcastMulligansEndEvent();
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("GameStateManager::StartGame");
        RulesEngine.Instance.BroadcastGameStartEvent();
    }

    private async void RegisterMatch()
    {
        Debug.Log("GameStateManager::RegisterMatch");
        //TODO: Register on the database    
    }
}
