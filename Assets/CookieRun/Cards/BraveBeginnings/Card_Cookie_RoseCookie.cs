using UnityEngine;

public class Card_Cookie_RoseCookie : Card_Cookie
{
    public override string CardId => "76944";
    public override string CardNumber => "BS1-015";
    public override string CardName => "Rose Cookie";
    public override string CardText => "《{R}{R}{R}》 Deals 3 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS1_015.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;
}