using UnityEngine;

public class Card_Cookie_TiramisuCookie : Card_Cookie
{
    public override string CardId => "77212";
    public override string CardNumber => "BS2-044";
    public override string CardName => "Tiramisu Cookie";
    public override string CardText => "《{B}》 Deals 1 damage. Then, 《can be used as {B}.》 If one of your opponent's Cookies is LV.1, deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_044.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 2;
}