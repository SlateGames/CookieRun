using UnityEngine;

public class Card_Cookie_MustardCookie : Card_Cookie
{
    public override string CardId => "77138";
    public override string CardNumber => "BS2-016";
    public override string CardName => "Mustard Cookie";
    public override string CardText => "《{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_016.png";
    public override int CardHealth => 1;
    public override int CardLevel => 3;
}