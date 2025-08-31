using UnityEngine;
using System.Collections.Generic;

public class GameState_Main : GameState_Base
{
    private Dictionary<int, CardColour> _unspentMana;

    public override void Enter()
    {
        _unspentMana = new Dictionary<int, CardColour>();
        _gamePhase = GamePhase.Main;
        base.Enter();
    }

    public override void Exit()
    {
        _unspentMana.Clear();
        base.Exit();
    }

    public override void HandleCardClick(ulong playerId, int cardMatchId)
    {
        base.HandleCardClick(playerId, cardMatchId);

        if (RulesEngine.Instance.GetGameStateManager().GetActivePlayerId() != playerId)
        {
            Debug.Log($"{playerId} is not the active player, that is {RulesEngine.Instance.GetGameStateManager().GetActivePlayerId()}");
            return;
        }

        GameZoneType zone = RulesEngine.Instance.GetGameZoneManager().GetZoneCardIsPresentIn(cardMatchId);
        if (zone == GameZoneType.Battle)
        {
            //TODO: Request mana if not enough in pool, then shift to battle
            //TODO: Need to track the card we are entering battle with. Maybe store it in the GSM?
            //RulesEngine.Instance.GetGameStateManager().ChangeState(new GameState_Battle());
        }
        if (zone == GameZoneType.Support)
        {
            bool isCardRested = RulesEngine.Instance.GetCardManager().IsCardRested(cardMatchId);
            if (isCardRested == false)
            {
                RulesEngine.Instance.GetCardManager().SetCardStateToRested(cardMatchId);
                CardColour cardColour = RulesEngine.Instance.GetCardManager().GetCardColour(cardMatchId);
                _unspentMana[cardMatchId] = cardColour;

                Debug.Log($"Rested card {cardMatchId} and added {cardColour} mana");
            }
            else
            {
                if (_unspentMana.ContainsKey(cardMatchId))
                {
                    RulesEngine.Instance.GetCardManager().SetCardStateToActive(cardMatchId);
                    CardColour removedMana = _unspentMana[cardMatchId];
                    _unspentMana.Remove(cardMatchId);

                    Debug.Log($"Unrested card {cardMatchId} and removed {removedMana} mana");
                }
                else
                {
                    Debug.Log($"Card {cardMatchId} is rested but has no unspent mana");
                }
            }
        }
        if(zone == GameZoneType.Hand)
        {
            //TODO: Play the card
        }
    }

    public override void PassPriority(ulong playerId)
    {
        Debug.Log("GameState_Main::PassPriority");

        if (playerId != RulesEngine.Instance.GetGameStateManager().GetActivePlayerId())
        {
            Debug.LogError("Only the active player can pass priority");
            return;
        }

        RulesEngine.Instance.TransitionToStateEnd();
    }
}