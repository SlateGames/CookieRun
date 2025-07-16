using UnityEngine;

public class Card_Cookie_LilacCookie : Card_Cookie
{
    public override string CardId => "76914";
    public override string CardNumber => "BS1-004";
    public override string CardName => "Lilac Cookie";
    public override string CardText => "【Activate】 《{R}{R}》 Return this Cookie to your hand.《{R}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS1_004.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}