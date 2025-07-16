using UnityEngine;

public class Card_Cookie_DevilCookie : Card_Cookie
{
    public override string CardId => "76930";
    public override string CardNumber => "BS1-010";
    public override string CardName => "Devil Cookie";
    public override string CardText => "《{N}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_010.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}