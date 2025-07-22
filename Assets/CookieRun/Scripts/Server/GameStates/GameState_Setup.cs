using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_Setup : GameState_Base
{
    private SetupPhase _subPhase;

    public GameState_Setup()
    {
        _subPhase = SetupPhase.GamePreparation;
    }

    public override void Enter()
    {
        _subPhase = SetupPhase.GamePreparation;
    }

    public override void Exit()
    {
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.LogError("Cannot pass priority during setup phase");
    }

    public override void AdvanceSetupPhase()
    {
        switch (_subPhase)
        {
            case SetupPhase.GamePreparation:
                _subPhase = SetupPhase.Mulligans;
                break;
            case SetupPhase.Mulligans:
                _subPhase = SetupPhase.PreGameCookiePlacement;
                break;
            case SetupPhase.PreGameCookiePlacement:
                //RulesEngine.Instance.GetGameStateManager().ChangeState(new ActiveState());
                break;
            default:
                Debug.LogError($"Unknown setup phase: {_subPhase}");
                return;
        }
    }

    public override GamePhase GetPhase()
    {
        return GamePhase.Setup;
    }

    public SetupPhase GetSetupSubPhase()
    {
        return _subPhase;
    }
}
