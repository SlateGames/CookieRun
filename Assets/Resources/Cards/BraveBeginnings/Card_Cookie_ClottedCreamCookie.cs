using UnityEngine;

public class Card_Cookie_ClottedCreamCookie : Card_Cookie
{
    public override string CardId => "77278";
    public override string CardNumber => "BS2-069";
    public override string CardName => "Clotted Cream Cookie";
    public override string CardText => "【On Play】 《Discard 1 card.》 Place up to 1 of your opponent's LV.1 Cookies from their battle area into the trash.《{P}{P}{P}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_069.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}