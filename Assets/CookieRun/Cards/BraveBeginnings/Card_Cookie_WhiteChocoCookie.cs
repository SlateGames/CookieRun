using UnityEngine;

public class Card_Cookie_WhiteChocoCookie : Card_Cookie
{
    public override string CardId => "77296";
    public override string CardNumber => "BS2-075";
    public override string CardName => "White Choco Cookie";
    public override string CardText => "《{P}》 Deals 1 damage. Then, 《can be used as {P}.》 If one of your opponent's Cookies is LV.1, deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_075.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 2;
}