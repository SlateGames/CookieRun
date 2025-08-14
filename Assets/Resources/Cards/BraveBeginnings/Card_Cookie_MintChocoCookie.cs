using UnityEngine;

public class Card_Cookie_MintChocoCookie : Card_Cookie
{
    public override string CardId => "77140";
    public override string CardNumber => "BS2-017";
    public override string CardName => "Mint Choco Cookie";
    public override string CardText => "《{G}》 Deals 1 damage. Then, 《can be used as {G}.》 If one of your opponent's Cookies is LV.1, deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS2_017.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;
}