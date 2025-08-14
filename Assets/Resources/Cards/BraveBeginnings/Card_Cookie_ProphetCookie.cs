using UnityEngine;

public class Card_Cookie_ProphetCookie : Card_Cookie
{
    public override string CardId => "77064";
    public override string CardNumber => "BS1-063";
    public override string CardName => "Prophet Cookie";
    public override string CardText => "【On Play】 《Place 1 card from your support area into the trash.》 Take 1 card from the top of your deck and place it in your support area as active.《{G}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_063.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}