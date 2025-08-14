using UnityEngine;

public class Card_Cookie_CyborgCookie : Card_Cookie
{
    public override string CardId => "76986";
    public override string CardNumber => "BS1-033";
    public override string CardName => "Cyborg Cookie";
    public override string CardText => "《{Y}{Y}》 Deals 1 damage. Then, 《can be used as {Y}.》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage for each Cookie that is LV.2 or higher in your break area.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_033.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;

    public Card_Cookie_CyborgCookie()
    {
        Debug.Log("Card_Cookie_CyborgCookie::Card_Cookie_CyborgCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_CyborgCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}