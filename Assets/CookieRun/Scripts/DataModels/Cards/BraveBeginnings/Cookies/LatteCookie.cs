using UnityEngine;

public class LatteCookie : Card_Cookie
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

    public LatteCookie()
    {
        Debug.Log("LatteCookie::LatteCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("LatteCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}