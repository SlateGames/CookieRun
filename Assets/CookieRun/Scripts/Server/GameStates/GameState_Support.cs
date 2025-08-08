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

    public override void HandleCardClick(ulong playerId, int cardMatchId)
    {
        base.HandleCardClick(playerId, cardMatchId);

        GameZoneType zone = RulesEngine.Instance.GetGameZoneManager().GetZoneCardIsPresentIn(cardMatchId);
        if (zone == GameZoneType.Hand)
        {
            RulesEngine.Instance.GetGameZoneManager().MoveCardFromZoneToZone(playerId, cardMatchId, GameZoneType.Hand, GameZoneType.Support);
            RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Main());
        }        
    }

    public void PlayerRefusesSupport(ulong playerId)
    {
        Debug.Log("GameState_Support::PlayerRefusesSupport");

        if (playerId != RulesEngine.Instance.GetGameStateManager().GetActivePlayerId())
        {
            Debug.LogError("Only the active player can make a Support decision");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Main());
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.Log("GameState_Support::PassPriority");
    }
}
