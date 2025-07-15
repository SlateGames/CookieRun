using UnityEngine;

public class Card_Cookie_AppleCookie : Card_Cookie
{
    public override string CardId => "77022";
    public override string CardNumber => "BS1-046";
    public override string CardName => "Apple Cookie";
    public override string CardText => "《{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_046.png.webp";
    public override int CardHealth => 1;
    public override int CardLevel => 3;
}