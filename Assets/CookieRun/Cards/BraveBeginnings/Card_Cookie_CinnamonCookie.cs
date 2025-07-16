using UnityEngine;

public class Card_Cookie_CinnamonCookie : Card_Cookie
{
    public override string CardId => "77002";
    public override string CardNumber => "BS1-038";
    public override string CardName => "Cinnamon Cookie";
    public override string CardText => "【Activate】 《{Y}{Y}》 《Place this Cookie in your break area.》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.《{Y}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_038.png";
    public override int CardHealth => 1;
    public override int CardLevel => 1;
}