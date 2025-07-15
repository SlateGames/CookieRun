using UnityEngine;

public class Card_Cookie_BlackRaisinCookie : Card_Cookie
{
    public override string CardId => "77178";
    public override string CardNumber => "BS2-031";
    public override string CardName => "Black Raisin Cookie";
    public override string CardText => "【Your Turn】 【On Play】 《Discard 3 cards.》 Select up to 2 of your opponent's Cookies. Deals 2 damage to 1 of the Cookies and 1 damage to the other.《{B}{B}{B}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_031.png.webp";
    public override int CardHealth => 5;
    public override int CardLevel => 3;
}