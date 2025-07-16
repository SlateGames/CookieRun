using UnityEngine;

public class Card_Cookie_GumballCookie : Card_Cookie
{
    public override string CardId => "77176";
    public override string CardNumber => "BS2-030";
    public override string CardName => "Gumball Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_030.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;
}