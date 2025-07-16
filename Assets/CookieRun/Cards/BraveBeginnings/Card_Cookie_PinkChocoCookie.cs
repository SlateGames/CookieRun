using UnityEngine;

public class Card_Cookie_PinkChocoCookie : Card_Cookie
{
    public override string CardId => "77294";
    public override string CardNumber => "BS2-074";
    public override string CardName => "Pink Choco Cookie";
    public override string CardText => "When this Cookie faints, place up to 1 of your opponent's LV.1 Cookies from their battle area into the trash.《{P}{P}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_074.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}