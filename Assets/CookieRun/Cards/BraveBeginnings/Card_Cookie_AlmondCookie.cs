using UnityEngine;

public class Card_Cookie_AlmondCookie : Card_Cookie
{
    public override string CardId => "77004";
    public override string CardNumber => "BS1-039";
    public override string CardName => "Almond Cookie";
    public override string CardText => "《{Y}{Y}》 Deals 1 damage. Then, select up to 2 of your opponent's Cookies. Those Cookies deal -1 attack damage each during your opponent's next turn.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_039.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;
}