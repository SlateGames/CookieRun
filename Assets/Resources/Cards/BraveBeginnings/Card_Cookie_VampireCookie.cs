using UnityEngine;

public class Card_Cookie_VampireCookie : Card_Cookie
{
    public override string CardId => "77122";
    public override string CardNumber => "BS2-010";
    public override string CardName => "Vampire Cookie";
    public override string CardText => "《{Y}》 Deals 1 damage. Then, 《can be used as {Y}.》 If one of your opponent's Cookies is LV.1, deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS2_010.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;
}