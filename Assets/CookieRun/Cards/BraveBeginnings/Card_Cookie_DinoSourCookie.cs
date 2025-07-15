using UnityEngine;

public class Card_Cookie_DinoSourCookie : Card_Cookie
{
    public override string CardId => "77234";
    public override string CardNumber => "BS2-054";
    public override string CardName => "Dino-Sour Cookie";
    public override string CardText => "《{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_054.png.webp";
    public override int CardHealth => 1;
    public override int CardLevel => 3;
}