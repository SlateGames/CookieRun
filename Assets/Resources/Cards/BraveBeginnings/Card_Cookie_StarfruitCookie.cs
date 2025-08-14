using UnityEngine;

public class Card_Cookie_StarfruitCookie : Card_Cookie
{
    public override string CardId => "77256";
    public override string CardNumber => "BS2-062";
    public override string CardName => "Starfruit Cookie";
    public override string CardText => "【On Play】 《{P}》 Other than this Cookie, you can place 1 {P} Cookie that is LV.2 or lower from your battle area into the trash. If you did, place up to 1 of your opponent's Cookies that is LV.2 or lower from their battle area into the trash.《{P}{P}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_062.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}