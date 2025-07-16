using UnityEngine;

public class Card_Cookie_CaptainIceCookie : Card_Cookie
{
    public override string CardId => "77210";
    public override string CardNumber => "BS2-043";
    public override string CardName => "Captain Ice Cookie";
    public override string CardText => "When this Cookie faints, 《discard 2 cards.》 Select up to 2 of your opponent's Cookies. Deals 1 damage to each of those Cookies.《{B}{B}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_043.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}