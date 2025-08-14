using UnityEngine;

public class Card_Cookie_PumpkinPieCookie : Card_Cookie
{
    public override string CardId => "77084";
    public override string CardNumber => "BS1-071";
    public override string CardName => "Pumpkin Pie Cookie";
    public override string CardText => "【On Play】 《{G}{G}》 Place 1 Cookie from your trash into your support area as active.《{G}{G}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_071.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;

    public Card_Cookie_PumpkinPieCookie()
    {
        Debug.Log("Card_Cookie_PumpkinPieCookie::Card_Cookie_PumpkinPieCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_PumpkinPieCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}