using UnityEngine;

public class GameState_Active : GameState_Base
{
    public override void Enter()
    {
        _gamePhase = GamePhase.Active;
        base.Enter();

        //TODO: Refresh all cards 

        //TODO: These should be handle by the GSM. The GSM should have a series of `EnterStateX` functions, one for each, that these can call. 
        RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Draw());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.Log("GameState_Active::PassPriority");
    }
}
