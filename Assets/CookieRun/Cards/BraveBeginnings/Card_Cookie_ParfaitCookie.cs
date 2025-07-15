using UnityEngine;

public class Card_Cookie_ParfaitCookie : Card_Cookie
{
    public override string CardId => "77214";
    public override string CardNumber => "BS2-045";
    public override string CardName => "Parfait Cookie";
    public override string CardText => "《{B}》 Deals 1 damage. Then, if there are 6 cards or less in your hand, you can draw 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_045.png.webp";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}