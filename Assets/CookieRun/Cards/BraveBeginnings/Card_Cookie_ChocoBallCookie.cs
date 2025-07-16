using UnityEngine;

public class Card_Cookie_ChocoBallCookie : Card_Cookie
{
    public override string CardId => "76946";
    public override string CardNumber => "BS1-016";
    public override string CardName => "Choco Ball Cookie";
    public override string CardText => "When this Cookie faints and you have 4 cards or less in your hand, select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.《{R}{R}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_016.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}