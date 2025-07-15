using UnityEngine;

public class Card_Cookie_MelonBunCookie : Card_Cookie
{
    public override string CardId => "76920";
    public override string CardNumber => "BS1-007";
    public override string CardName => "Melon Bun Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_007.png.webp";
    public override int CardHealth => 4;
    public override int CardLevel => 1;
}