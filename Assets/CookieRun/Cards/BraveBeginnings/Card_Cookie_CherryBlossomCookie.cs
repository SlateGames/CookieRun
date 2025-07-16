using UnityEngine;

public class Card_Cookie_CherryBlossomCookie : Card_Cookie
{
    public override string CardId => "77248";
    public override string CardNumber => "BS2-059";
    public override string CardName => "Cherry Blossom Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_059.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;
}