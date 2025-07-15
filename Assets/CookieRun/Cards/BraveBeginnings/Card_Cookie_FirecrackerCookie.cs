using UnityEngine;

public class Card_Cookie_FirecrackerCookie : Card_Cookie
{
    public override string CardId => "77020";
    public override string CardNumber => "BS1-045";
    public override string CardName => "Firecracker Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_045.png.webp";
    public override int CardHealth => 4;
    public override int CardLevel => 3;
}