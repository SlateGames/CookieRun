using UnityEngine;

public class Card_Cookie_BeetCookie : Card_Cookie
{
    public override string CardId => "77250";
    public override string CardNumber => "BS2-060";
    public override string CardName => "Beet Cookie";
    public override string CardText => "When this Cookie faints and your opponent has 20 cards or more in their trash, you can draw 1 card from your deck.《{P}{P}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_060.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}