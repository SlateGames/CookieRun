using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_End : GameState_Base
{
    public override void Enter()
    {
        _gamePhase = GamePhase.End;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PassPriority(ulong playerId)
    {
        if (playerId != RulesEngine.Instance.GetGameStateManager().GetActivePlayerId())
        {
            Debug.LogError("Only the active player can pass priority");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().EndTurn();
        RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Active());
    }
}
