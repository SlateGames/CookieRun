using UnityEngine;

public class Card_Cookie_PeachCookie : Card_Cookie
{
    public override string CardId => "77058";
    public override string CardNumber => "BS1-061";
    public override string CardName => "Peach Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_061.png.webp";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}