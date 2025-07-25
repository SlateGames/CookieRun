using System;
using System.Collections.Generic;
using UnityEngine;

public enum GameZoneType
{
    Battlefield,
    Break,
    Deck,
    Discard,
    Hand,
    Stage,
    Support,
    Invalid
}

public class GameZone_Base
{
    //TODO: How can I remove these?
    public event Action<int, GameZoneType> OnCardEnter; 
    public event Action<int, GameZoneType> OnCardLeave; 

    protected List<int> CardsInZone = new List<int>();

    public GameZoneType ZoneType;

    public ulong OwningPlayerId;

    public IReadOnlyList<int> GetCards()
    {
        Debug.Log("GameZone_Base::GetCards");
        return new List<int>(CardsInZone);
    }

    public virtual bool IsCardPresent(int cardMatchId)
    {
        Debug.Log("GameZone_Base::IsCardPresent");
        return CardsInZone.Contains(cardMatchId);
    }

    public virtual void AddCard(int cardMatchId)
    {
        Debug.Log("GameZone_Base::AddCard");

        if (!CardsInZone.Contains(cardMatchId))
        {
            CardsInZone.Add(cardMatchId);
            OnCardEnter?.Invoke(cardMatchId, ZoneType); 
        }
    }

    public virtual void RemoveCard(int cardMatchId)
    {
        Debug.Log("GameZone_Base::RemoveCard");

        if (CardsInZone.Contains(cardMatchId))
        {
            CardsInZone.Remove(cardMatchId);
            OnCardLeave?.Invoke(cardMatchId, ZoneType);
        }
    }

    public virtual bool CanAddCardToZone(int cardMatchId)
    {
        Debug.Log("GameZone_Base::CanAddCardToZone");
        return true;
    }
}
