using UnityEngine;

public class Card_Cookie_IceJugglerCookie : Card_Cookie
{
    public override string CardId => "76970";
    public override string CardNumber => "BS1-027";
    public override string CardName => "Ice Juggler Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_027.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}