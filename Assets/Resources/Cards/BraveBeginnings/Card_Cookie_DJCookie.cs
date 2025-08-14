using UnityEngine;

public class Card_Cookie_DJCookie : Card_Cookie
{
    public override string CardId => "77154";
    public override string CardNumber => "BS2-023";
    public override string CardName => "DJ Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_023.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;
}