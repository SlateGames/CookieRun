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
        //if (playerId != RulesEngine.Instance.GetGameStateManager().GetActivePlayerId())
        //{
        //    Debug.LogError("Only the active player can pass priority");
        //    return;
        //}

        switch (_subPhase)
        {
            case BattlePhase.Attack:
                _subPhase = BattlePhase.Trap;
                break;
            case BattlePhase.Trap:
                _subPhase = BattlePhase.Resolution;
                break;
            case BattlePhase.Resolution:
                //RulesEngine.Instance.GetGameStateManager().ChangeState(new MainState());
                break;
            default:
                Debug.LogError($"Unknown battle phase: {_subPhase}");
                return;
        }
    }

    public override void PassTrapPriority(ulong playerId)
    {
        if (_subPhase != BattlePhase.Trap)
        {
            Debug.LogError("Can only pass trap priority during Trap phase");
            return;
        }

        //ulong activePlayerId = RulesEngine.Instance.GetGameStateManager().GetActivePlayerId();
        //ulong player1Id = RulesEngine.Instance.GetGameStateManager().GetPlayer1Id();
        //ulong player2Id = RulesEngine.Instance.GetGameStateManager().GetPlayer2Id();
        //ulong nonActivePlayerId = activePlayerId == player1Id ? player2Id : player1Id;

        //if (playerId != nonActivePlayerId)
        //{
        //    Debug.LogError("Only the non-active player can pass trap priority");
        //    return;
        //}

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
}
