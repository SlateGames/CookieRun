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
        ulong ownerId = RulesEngine.Instance.GetGameZoneManager().GetControllerOfCardByMatchId(MatchID);
        List<int> topCards = RulesEngine.Instance.GetGameZoneManager().GetTopCardMatchIds(ownerId, healAmount, MatchID);

        foreach (int cardId in topCards)
        {
            //TODO: Have to notify the player which card to put these under. Maybe add a special broadcast for the health pool?
            RulesEngine.Instance.GetGameZoneManager().MoveCardFromZoneToZone(ownerId, cardId, GameZoneType.Deck, GameZoneType.HealthPool);
            healthPool.Enqueue(cardId);
        }
    }
}
