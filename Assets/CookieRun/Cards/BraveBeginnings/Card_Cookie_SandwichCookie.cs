using UnityEngine;

public class Card_Cookie_SandwichCookie : Card_Cookie
{
    public override string CardId => "76990";
    public override string CardNumber => "BS1-034";
    public override string CardName => "Sandwich Cookie";
    public override string CardText => "【On Play】 《{Y}》 Select up to 1 of your other Cookies. That Cookie gains +1 HP.《{Y}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_034.png.webp";
    public override int CardHealth => 1;
    public override int CardLevel => 1;
}