using UnityEngine;

public class Card_Cookie_EarlGreyCookie : Card_Cookie
{
    public override string CardId => "77006";
    public override string CardNumber => "BS1-040";
    public override string CardName => "Earl Grey Cookie";
    public override string CardText => "《{Y}{Y}{Y}》 Deals 3 damage.FLIP 《Discard 1 card.》 If your break area is LV.6 or higher, the Cookie with this card attached for HP gains +2 HP.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_040.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 3;
}