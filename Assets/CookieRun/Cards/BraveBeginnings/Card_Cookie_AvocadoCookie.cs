using UnityEngine;

public class Card_Cookie_AvocadoCookie : Card_Cookie
{
    public override string CardId => "77200";
    public override string CardNumber => "BS2-039";
    public override string CardName => "Avocado Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《{B}》 《Discard 2 cards.》 Select up to 2 of your Cookies. During this turn, those Cookies deal +1 attack damage.《{B}{B}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_039.png.webp";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}