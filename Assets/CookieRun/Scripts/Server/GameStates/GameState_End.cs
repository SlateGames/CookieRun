using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_End : GameState_Base
{
    public override void Enter()
    {
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

        RulesEngine.Instance.GetGameStateManager().EndTurn();
        RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Active());
    }

    public override GamePhase GetPhase()
    {
        return GamePhase.End;
    }
}
