using UnityEngine;

public class Card_Cookie_RollCakeCookie : Card_Cookie
{
    public override string CardId => "76916";
    public override string CardNumber => "BS1-005";
    public override string CardName => "Roll Cake Cookie";
    public override string CardText => "《{R}{R}》 Deals 1 damage. Then, select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS1_005.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}