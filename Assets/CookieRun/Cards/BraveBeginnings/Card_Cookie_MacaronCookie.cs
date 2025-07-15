using UnityEngine;

public class Card_Cookie_MacaronCookie : Card_Cookie
{
    public override string CardId => "77104";
    public override string CardNumber => "BS2-002";
    public override string CardName => "Macaron Cookie";
    public override string CardText => "【On Play】 《{R}》 Place up to 1 of your opponent's stage cards in the trash.《{R}{R}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS2_002.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}