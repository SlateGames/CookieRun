using UnityEngine;

public class GameState_Support : GameState_Base
{
    public override void Enter()
    {
        _gamePhase = GamePhase.Support;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.Log("GameState_Support::PassPriority");

        if (playerId != RulesEngine.Instance.GetGameStateManager().GetActivePlayerId())
        {
            Debug.LogError("Only the active player can pass priority");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Main());
    }
}
