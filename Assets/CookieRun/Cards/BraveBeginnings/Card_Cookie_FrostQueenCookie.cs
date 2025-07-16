using UnityEngine;

public class Card_Cookie_FrostQueenCookie : Card_Cookie
{
    public override string CardId => "77186";
    public override string CardNumber => "BS2-034";
    public override string CardName => "Frost Queen Cookie";
    public override string CardText => "《{B}{B}{B}》 Deals 3 damage.FLIP If your break area is LV.4 or higher, you can draw up to 2 cards from your deck.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_034.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;
}