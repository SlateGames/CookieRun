using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_Cookie_", menuName = "Cards/Cookie Card", order = 1)]
public class Card_Cookie : Card_Base
{
    public int CardHealth = 0;
    public int CardLevel = 0;

    private Queue<int> healthPool = new Queue<int>();

    protected override CardType GetCardType()
    {
        return CardType.Cookie;
    }

    public int TakeDamage()
    {
        //TODO: Discard that many cards, check for death
        if (healthPool.Count > 0)
        {
            return healthPool.Dequeue();
        }

        return CookieRunConstants.INVALID_CARD_MATCH_ID;
    }

    public void Heal(int healAmount)
    {
        //TODO: Add that many cards
    }
}
