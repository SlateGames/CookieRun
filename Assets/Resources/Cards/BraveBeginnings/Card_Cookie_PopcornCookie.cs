using UnityEngine;

public class Card_Cookie_PopcornCookie : Card_Cookie
{
    public override string CardId => "76952";
    public override string CardNumber => "BS1-018";
    public override string CardName => "Popcorn Cookie";
    public override string CardText => "《{R}》 Deals 1 damage.FLIP 《Discard 1 card.》 The Cookie with this card attached for HP gains +1 HP.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_018.png";
    public override int CardHealth => 1;
    public override int CardLevel => 1;
}