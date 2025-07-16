using UnityEngine;

public class Card_Cookie_StrawberryCookie : Card_Cookie
{
    public override string CardId => "77156";
    public override string CardNumber => "BS2-024";
    public override string CardName => "Strawberry Cookie";
    public override string CardText => "《{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_024.png";
    public override int CardHealth => 1;
    public override int CardLevel => 3;
}