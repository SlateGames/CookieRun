using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_Draw : GameState_Base
{
    public override void Enter()
    {
        _gamePhase = GamePhase.Draw;
        base.Enter();

        RulesEngine.Instance.GetGameStateManager().CurrentTurn++;
        if (RulesEngine.Instance.GetGameStateManager().CurrentTurn > 1)
        {
            RulesEngine.Instance.GetGameZoneManager().DrawCards(RulesEngine.Instance.GetGameStateManager().GetActivePlayerId(), 2, CookieRunConstants.GAME_ACTION);
        }

        RulesEngine.Instance.TransitionToStateSupport();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.Log("GameState_Draw::PassPriority");
    }
}
