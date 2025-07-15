using UnityEngine;

public class Card_Cookie_MalaSauceCookie : Card_Cookie
{
    public override string CardId => "76918";
    public override string CardNumber => "BS1-006";
    public override string CardName => "Mala Sauce Cookie";
    public override string CardText => "If this Cookie remains in the battle area after receiving damage, select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.《{R}{R}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS1_006.png.webp";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}