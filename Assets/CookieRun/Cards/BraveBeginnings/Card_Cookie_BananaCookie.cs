using UnityEngine;

public class Card_Cookie_BananaCookie : Card_Cookie
{
    public override string CardId => "76984";
    public override string CardNumber => "BS1-032";
    public override string CardName => "Banana Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_032.png";
    public override int CardHealth => 4;
    public override int CardLevel => 1;
}