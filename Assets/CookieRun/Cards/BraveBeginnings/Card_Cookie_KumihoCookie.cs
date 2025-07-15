using UnityEngine;

public class Card_Cookie_KumihoCookie : Card_Cookie
{
    public override string CardId => "76906";
    public override string CardNumber => "BS1-002";
    public override string CardName => "Kumiho Cookie";
    public override string CardText => "《{R}{R}{R}》 Deals 3 damage.FLIP 《Discard 1 card.》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS1_002.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 3;
}