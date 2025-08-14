using UnityEngine;

public class Card_Cookie_LatteCookie : Card_Cookie
{
    public override string CardId => "76972";
    public override string CardNumber => "BS1-028";
    public override string CardName => "Latte Cookie";
    public override string CardText => "【On Play】 《{Y}》 Select up to 1 of your other Cookies. That Cookie gains +1 HP.《{Y}{Y}{Y}》 Deals 2 damage. Then, if your break area is LV.5 or higher, deals 1 damage to all of your opponent's Cookies.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_028.png";
    public override int CardHealth => 5;
    public override int CardLevel => 3;

    public Card_Cookie_LatteCookie()
    {
        Debug.Log("Card_Cookie_LatteCookie::Card_Cookie_LatteCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_LatteCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}