using UnityEngine;

public class Card_Cookie_LimeCookie : Card_Cookie
{
    public override string CardId => "76976";
    public override string CardNumber => "BS1-029";
    public override string CardName => "Lime Cookie";
    public override string CardText => "【On Play】 If your break area is LV.3 or higher, draw 1 card from your deck and discard 1 card.《{Y}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_029.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}