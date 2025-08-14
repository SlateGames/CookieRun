using UnityEngine;

public class Card_Cookie_KiwiCookie : Card_Cookie
{
    public override string CardId => "77082";
    public override string CardNumber => "BS1-070";
    public override string CardName => "Kiwi Cookie";
    public override string CardText => "《{G}{N}》 Deals 1 damage. Then, return 1 LV.1 Cookie from your support area to your hand.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_070.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;

    public Card_Cookie_KiwiCookie()
    {
        Debug.Log("Card_Cookie_KiwiCookie::Card_Cookie_KiwiCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_KiwiCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}