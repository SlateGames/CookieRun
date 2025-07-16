using UnityEngine;

public class Card_Cookie_OnionCookie : Card_Cookie
{
    public override string CardId => "77128";
    public override string CardNumber => "BS2-012";
    public override string CardName => "Onion Cookie";
    public override string CardText => "【On Play】 《{Y}》 Place up to 1 of your opponent's stage cards in the trash.《{Y}{Y}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS2_012.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}