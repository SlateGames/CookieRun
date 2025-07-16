using UnityEngine;

public class Card_Cookie_SparklingCookie : Card_Cookie
{
    public override string CardId => "77198";
    public override string CardNumber => "BS2-038";
    public override string CardName => "Sparkling Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_038.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}