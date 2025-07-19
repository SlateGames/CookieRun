using UnityEngine;

public class Card_Cookie_HeroCookie : Card_Cookie
{
    public override string CardId => "77298";
    public override string CardNumber => "BS2-076";
    public override string CardName => "Hero Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_076.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;
}