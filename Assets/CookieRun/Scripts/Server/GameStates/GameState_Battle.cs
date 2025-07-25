using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameState_Battle : GameState_Base
{
    private BattlePhase _subPhase;

    public GameState_Battle()
    {
        _subPhase = BattlePhase.Attack;
    }

    public override void Enter()
    {
        _subPhase = BattlePhase.Attack;
    }

    public override void Exit()
    {
    }

    public override void PassPriority(ulong playerId)
    {
        if (playerId != RulesEngine.Instance.GetGameStateManager().GetActivePlayerId())
        {
            Debug.LogError("Only the active player can pass priority");
            return;
        }

        switch (_subPhase)
        {
            case BattlePhase.Attack:
                _subPhase = BattlePhase.Trap;
                break;
            case BattlePhase.Trap:
                _subPhase = BattlePhase.Resolution;
                break;
            case BattlePhase.Resolution:
                RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Main());
                break;
            default:
                Debug.LogError($"Unknown battle phase: {_subPhase}");
                return;
        }
    }

    public void PassTrapPriority(ulong playerId)
    {
        if (_subPhase != BattlePhase.Trap)
        {
            Debug.LogError("Can only pass trap priority during Trap phase");
            return;
        }

        ulong activePlayerId = RulesEngine.Instance.GetGameStateManager().GetActivePlayerId();
        ulong player1Id = RulesEngine.Instance.GetGameStateManager().Player1Id;
        ulong player2Id = RulesEngine.Instance.GetGameStateManager().Player2Id;
        ulong nonActivePlayerId = activePlayerId == player1Id ? player2Id : player1Id;

        if (playerId != nonActivePlayerId)
        {
            Debug.LogError("Only the non-active player can pass trap priority");
            return;
        }

        _subPhase = BattlePhase.Resolution;
    }

    public override GamePhase GetPhase()
    {
        return GamePhase.Battle;
    }

    public BattlePhase GetBattleSubPhase()
    {
        return _subPhase;
    }

    public void DealCombatDamageToCookie(int sourceCardMatchId, int targetCardMatchId, int damageAmount)
    {
        Debug.Log("GameStateManager::DealCombatDamageToCookie");

        if (damageAmount <= 0)
        {
            Debug.Log($"Cannot deal {damageAmount} damage");
            return;
        }

        Card_Cookie targetCard = (Card_Cookie)RulesEngine.Instance.GetCardManager().GetCardByMatchId(targetCardMatchId);
        if (targetCard == null)
        {
            Debug.LogError("No card with Match ID " + targetCardMatchId + " exists.");
            return;
        }
        for (int i = 0; i < damageAmount; i++)
        {
            //TODO: Flip the card and stuff
            int cardToFlip = targetCard.TakeDamage(1);
        }

        RulesEngine.Instance.GetCardManager().GenericUpdateCard(targetCard);
    }
}
