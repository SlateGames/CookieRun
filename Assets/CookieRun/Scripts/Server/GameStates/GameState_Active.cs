using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_Active : GameState_Base
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

        //TODO: These should be handle by the GSM. The GSM should have a series of `EnterStateX` functions, one for each, that these can call. 
        //RulesEngine.Instance.GetGameStateManager().ChangeState(new DrawState());
    }

    public override GamePhase GetPhase()
    {
        return GamePhase.Active;
    }
}
