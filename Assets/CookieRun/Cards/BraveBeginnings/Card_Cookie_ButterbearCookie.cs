using UnityEngine;

public class Card_Cookie_ButterbearCookie : Card_Cookie
{
    public override string CardId => "77056";
    public override string CardNumber => "BS1-060";
    public override string CardName => "Butterbear Cookie";
    public override string CardText => "《{N}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_060.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}