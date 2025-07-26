using UnityEngine;

public class GameState_Main : GameState_Base
{
    public override void Enter()
    {
        _gamePhase = GamePhase.Main;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.Log("GameState_Main::PassPriority");

        if (playerId != RulesEngine.Instance.GetGameStateManager().GetActivePlayerId())
        {
            Debug.LogError("Only the active player can pass priority");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_End());
    }

    public void EnterBattle()
    {
        RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Battle());
    }
}
