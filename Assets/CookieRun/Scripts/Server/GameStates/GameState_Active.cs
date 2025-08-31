using UnityEngine;

public class GameState_Active : GameState_Base
{
    public override void Enter()
    {
        _gamePhase = GamePhase.Active;
        base.Enter();

        RefreshCardsForPlayer(RulesEngine.Instance.GetGameStateManager().Player1Id); 
        RefreshCardsForPlayer(RulesEngine.Instance.GetGameStateManager().Player2Id); 

        RulesEngine.Instance.TransitionToStateDraw();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.Log("GameState_Active::PassPriority");
    }

    private void RefreshCardsForPlayer(ulong playerId)
    {
        var cardsToRefresh = RulesEngine.Instance.GetGameZoneManager().GetCardsInPlayForPlayer(playerId);
        foreach(var cardMatchId in cardsToRefresh)
        {
            RulesEngine.Instance.GetCardManager().SetCardStateToActive(cardMatchId);
        }
    }
}
