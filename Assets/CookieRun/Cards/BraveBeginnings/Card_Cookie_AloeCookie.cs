using UnityEngine;

public class Card_Cookie_AloeCookie : Card_Cookie
{
    public override string CardId => "77202";
    public override string CardNumber => "BS2-040";
    public override string CardName => "Aloe Cookie";
    public override string CardText => "When this Cookie faints, view the top 3 cards of your deck. Out of the 3 cards, select 1 {B} card, show it to your opponent, and place that card in your hand. Then, return the remaining cards to the bottom of your deck in any order.《{B}{B}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_040.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}