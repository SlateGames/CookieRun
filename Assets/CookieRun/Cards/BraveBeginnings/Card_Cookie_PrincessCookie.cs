using UnityEngine;

public class Card_Cookie_PrincessCookie : Card_Cookie
{
    public override string CardId => "77118";
    public override string CardNumber => "BS2-008";
    public override string CardName => "Princess Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_008.png.webp";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}