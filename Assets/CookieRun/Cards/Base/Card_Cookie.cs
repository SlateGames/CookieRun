using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCookieCard", menuName = "Cards/Cookie Card", order = 1)]
public class Card_Cookie : Card_Base
{
    [SerializeField] private int _cardHealth;
    [SerializeField] private int _cardLevel;

    private Queue<int> healthPool = new Queue<int>();

    public override void OnPlay()
    {
        base.OnPlay();
        //TODO: Setup health pool
        
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
