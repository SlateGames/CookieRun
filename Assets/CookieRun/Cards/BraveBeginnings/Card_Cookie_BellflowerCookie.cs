using UnityEngine;

public class Card_Cookie_BellflowerCookie : Card_Cookie
{
    public override string CardId => "77050";
    public override string CardNumber => "BS1-057";
    public override string CardName => "Bellflower Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_057.png.webp";
    public override int CardHealth => 4;
    public override int CardLevel => 1;
}