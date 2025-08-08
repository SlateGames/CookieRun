using UnityEngine;

public class GameState_End : GameState_Base
{
    public override void Enter()
    {
        _gamePhase = GamePhase.End;
        base.Enter();

        RulesEngine.Instance.GetGameStateManager().EndTurn();
        RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Active());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.Log("GameState_End::PassPriority");
    }
}
