using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState_Base
{
    protected GamePhase _gamePhase;
    public abstract void PassPriority(ulong playerId);

    public virtual void Enter()
    {
        RulesEngine.Instance.BroadcastPlayerPlayerEnterGamePhaseEvent(RulesEngine.Instance.GetGameStateManager().GetActivePlayerId(), _gamePhase);
    }

    public virtual void Exit()
    {
        RulesEngine.Instance.BroadcastPlayerPlayerExitGamePhaseEvent(RulesEngine.Instance.GetGameStateManager().GetActivePlayerId(), _gamePhase);
    }
    
    public virtual void HandleCardClick(ulong playerId, int cardMatchId)
    {
        
    }

    public virtual GamePhase GetPhase()
    {
        return _gamePhase;
    }
}
