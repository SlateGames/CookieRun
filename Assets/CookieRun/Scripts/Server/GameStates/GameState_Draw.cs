using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_Draw : GameState_Base
{
    public override void Enter()
    {
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

        //RulesEngine.Instance.GetGameStateManager().ChangeState(new SupportState());
    }

    public override GamePhase GetPhase()
    {
        return GamePhase.Draw;
    }
}
