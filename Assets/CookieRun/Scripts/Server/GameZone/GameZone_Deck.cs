using System.Collections.Generic;
using UnityEngine;

public class GameZone_Deck : GameZone_Base
{
    public GameZone_Deck()
    {
        Debug.Log("GameZone_Deck::GameZone_Deck");
        ZoneType = GameZoneType.Deck;
    }

    public void Shuffle()
    {
        Debug.Log("GameZone_Deck::Shuffle");

        RulesEngine.Instance.BroadcastDeckShuffledEvent(OwningPlayerId);

        for (int i = 0; i < CardsInZone.Count; i++)
        {
            Debug.Log($"Card at index {i} has Match ID {CardsInZone[i]}");
        }

        for (int i = CardsInZone.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            int temp = CardsInZone[i];
            CardsInZone[i] = CardsInZone[randomIndex];
            CardsInZone[randomIndex] = temp;
        }

        Debug.Log("GameZone_Deck: Deck has been shuffled, new order of cards:");
        for (int i = 0; i < CardsInZone.Count; i++)
        {
            Debug.Log($"Card at index {i} has Match ID {CardsInZone[i]}");
        }
    }

    public int GetTopCardMatchID()
    {
        Debug.Log("GameZone_Deck::GetTopCardMatchID");

        if (CardsInZone.Count == 0)
        {
            return RulesEngine.INVALID_CARD_MATCH_ID;
        }

        return CardsInZone[0];
    }
}
