using UnityEngine;

public class Card_Cookie_SeaFairyCookie : Card_Cookie
{
    public override string CardId => "77172";
    public override string CardNumber => "BS2-029";
    public override string CardName => "Sea Fairy Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《Discard 1 card.》 Select up to 1 Cookie that is LV.2 or lower from your battle area and return them to your hand.《{B}{B}{B}{B}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.UltraRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_029.png.webp";
    public override int CardHealth => 5;
    public override int CardLevel => 3;
}