using System.Collections.Generic;

public abstract class Card_Cookie : Card_Base
{
    public virtual int CardHealth => 0;
    public virtual int CardLevel => 0;

    private Queue<int> healthPool = new Queue<int>();

    public int TakeDamage()
    {
        //TODO: Discard that many cards, check for death
        if (healthPool.Count > 0)
        {
            return healthPool.Dequeue();
        }

        return RulesEngine.INVALID_CARD_MATCH_ID;
    }

    public void Heal(int healAmount)
    {
        //TODO: Add that many cards
    }
}
