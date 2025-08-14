using UnityEngine;

public class Card_Cookie_SaltCookie : Card_Cookie
{
    public override string CardId => "77190";
    public override string CardNumber => "BS2-035";
    public override string CardName => "Salt Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_035.png";
    public override int CardHealth => 4;
    public override int CardLevel => 1;
}