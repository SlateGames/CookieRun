using UnityEngine;

public class Card_Cookie_BellPepperCookie : Card_Cookie
{
    public override string CardId => "77016";
    public override string CardNumber => "BS1-044";
    public override string CardName => "Bell Pepper Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《{Y}》 《Discard 1 card.》 If this Cookie's HP is less than 3, gain +1 HP.《{Y}{Y}{Y}》 Deals 2 damage. Then, 《can be used as {Y}{Y}.》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_044.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;
}