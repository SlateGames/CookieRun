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
}
