using System.Collections.Generic;

public abstract class Card_Cookie : Card_Base
{
    public virtual int CardHealth => 0;
    public virtual int CardLevel => 0;

    private Queue<int> healthPool = new Queue<int>();

    public override void OnEnterZone(GameZoneType gameZone)
    {
        base.OnEnterZone(gameZone);

        if(gameZone == GameZoneType.Battle)
        {
            Heal(CardHealth);
        }
    }

    public int TakeDamage()
    {
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
