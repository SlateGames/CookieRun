using UnityEngine;

public class Card_Cookie_AlchemistCookie : Card_Cookie
{
    public override string CardId => "77264";
    public override string CardNumber => "BS2-064";
    public override string CardName => "Alchemist Cookie";
    public override string CardText => "【On Play】 Place up to 1 of your opponent's Cookies whose remaining HP is 2 or less from their battle area into the trash.《{P}{P}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_064.png.webp";
    public override int CardHealth => 1;
    public override int CardLevel => 2;
}