using UnityEngine;

public class Card_Cookie_CottonCookie : Card_Cookie
{
    public override string CardId => "77164";
    public override string CardNumber => "BS2-027";
    public override string CardName => "Cotton Cookie";
    public override string CardText => "【On Play】 《Discard 2 cards.》 Select up to 2 of your Cookies. Those Cookies gain +1 HP.《{B}{B}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_027.png.webp";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}