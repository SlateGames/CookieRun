using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState_Base
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void PassPriority(ulong playerId);
    public abstract GamePhase GetPhase();

    public virtual void AdvanceSetupPhase()
    {
        throw new InvalidOperationException("Cannot advance setup phase in this state");
    }

    public virtual void EnterBattle()
    {
        throw new InvalidOperationException("Cannot enter battle in this state");
    }

    public virtual void PassTrapPriority(ulong playerId)
    {
        throw new InvalidOperationException("Cannot pass trap priority in this state");
    }
}
