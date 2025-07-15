using UnityEngine;

public class Card_Cookie_BlueberryPieCookie : Card_Cookie
{
    public override string CardId => "77182";
    public override string CardNumber => "BS2-032";
    public override string CardName => "Blueberry Pie Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_032.png.webp";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}