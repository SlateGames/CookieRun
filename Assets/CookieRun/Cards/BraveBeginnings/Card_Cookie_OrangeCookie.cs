using UnityEngine;

public class Card_Cookie_OrangeCookie : Card_Cookie
{
    public override string CardId => "77010";
    public override string CardNumber => "BS1-041";
    public override string CardName => "Orange Cookie";
    public override string CardText => "《{Y}》 Deals 1 damage.FLIP 《Discard 1 card.》 The Cookie with this card attached for HP gains +1 HP.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_041.png";
    public override int CardHealth => 1;
    public override int CardLevel => 1;
}