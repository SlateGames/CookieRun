using UnityEngine;

public class Card_Cookie_CandlelightCookie : Card_Cookie
{
    public override string CardId => "77142";
    public override string CardNumber => "BS2-018";
    public override string CardName => "Candlelight Cookie";
    public override string CardText => "【On Play】 《{G}》 Place up to 1 of your opponent's stage cards in the trash.《{G}{G}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImagePath => "BS2_018.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}