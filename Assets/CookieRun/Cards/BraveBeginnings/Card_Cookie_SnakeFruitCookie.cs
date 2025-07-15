using UnityEngine;

public class Card_Cookie_SnakeFruitCookie : Card_Cookie
{
    public override string CardId => "76994";
    public override string CardNumber => "BS1-036";
    public override string CardName => "Snake Fruit Cookie";
    public override string CardText => "【On Play】 《{Y}{Y}》 Select up to 1 {Y} LV.1 Cookie from your break area and play it.《{Y}{Y}{Y}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_036.png.webp";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}