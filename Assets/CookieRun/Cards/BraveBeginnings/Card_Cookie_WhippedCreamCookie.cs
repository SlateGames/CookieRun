using UnityEngine;

public class Card_Cookie_WhippedCreamCookie : Card_Cookie
{
    public override string CardId => "76958";
    public override string CardNumber => "BS1-021";
    public override string CardName => "Whipped Cream Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_021.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}