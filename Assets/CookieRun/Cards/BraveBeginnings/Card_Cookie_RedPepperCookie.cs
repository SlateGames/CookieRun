using UnityEngine;

public class Card_Cookie_RedPepperCookie : Card_Cookie
{
    public override string CardId => "76956";
    public override string CardNumber => "BS1-020";
    public override string CardName => "Red Pepper Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_020.png.webp";
    public override int CardHealth => 4;
    public override int CardLevel => 3;
}