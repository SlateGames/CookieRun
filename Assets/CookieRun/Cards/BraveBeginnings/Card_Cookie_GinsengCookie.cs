using UnityEngine;

public class Card_Cookie_GinsengCookie : Card_Cookie
{
    public override string CardId => "77066";
    public override string CardNumber => "BS1-064";
    public override string CardName => "Ginseng Cookie";
    public override string CardText => "《{G}{G}》 Deals 2 damage. Then, 《can be used as {G}.》 If your support area contains 7 or more cards, 1 of your other Cookies gains +1 HP.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImagePath => "BS1_064.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;
}