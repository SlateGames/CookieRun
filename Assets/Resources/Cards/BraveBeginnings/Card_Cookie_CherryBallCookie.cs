using UnityEngine;

public class Card_Cookie_CherryBallCookie : Card_Cookie
{
    public override string CardId => "76932";
    public override string CardNumber => "BS1-011";
    public override string CardName => "Cherry Ball Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_011.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}