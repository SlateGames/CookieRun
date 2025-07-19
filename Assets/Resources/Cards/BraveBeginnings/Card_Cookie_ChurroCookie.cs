using UnityEngine;

public class Card_Cookie_ChurroCookie : Card_Cookie
{
    public override string CardId => "77074";
    public override string CardNumber => "BS1-067";
    public override string CardName => "Churro Cookie";
    public override string CardText => "《{G}{G}{G}》 Deals 3 damage.FLIP 《Discard 1 card.》 If your support area contains 4 or more cards, place this card in your support area as rested.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_067.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;
}