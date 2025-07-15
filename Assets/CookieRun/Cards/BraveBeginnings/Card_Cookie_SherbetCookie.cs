using UnityEngine;

public class Card_Cookie_SherbetCookie : Card_Cookie
{
    public override string CardId => "77192";
    public override string CardNumber => "BS2-036";
    public override string CardName => "Sherbet Cookie";
    public override string CardText => "【On Play】 《Select 1 LV.1 Cookie from your battle area and return them to the bottom of your deck.》 You can draw 1 card from your deck.《{B}{B}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.UltraRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_036.png.webp";
    public override int CardHealth => 5;
    public override int CardLevel => 2;
}