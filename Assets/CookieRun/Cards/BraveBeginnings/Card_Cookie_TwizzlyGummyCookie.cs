using UnityEngine;

public class Card_Cookie_TwizzlyGummyCookie : Card_Cookie
{
    public override string CardId => "77284";
    public override string CardNumber => "BS2-071";
    public override string CardName => "Twizzly Gummy Cookie";
    public override string CardText => "【Activate】 《{P}》 《Place this Cookie in the trash.》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.《{P}{P}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_071.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}