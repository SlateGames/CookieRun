using UnityEngine;

public class GoblinCookie : Card_Cookie
{
    public override string CardId => "76904";
    public override string CardNumber => "BS1-001";
    public override string CardName => "Goblin Cookie";
    public override string CardText => "【On Play】 《Discard 1 card.》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.《{R}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_001.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;

    public GoblinCookie()
    {
        Debug.Log("GoblinCookie::GoblinCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("GoblinCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}