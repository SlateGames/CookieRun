using UnityEngine;

public class Card_Cookie_LillybellCookie : Card_Cookie
{
    public override string CardId => "77070";
    public override string CardNumber => "BS1-066";
    public override string CardName => "Lillybell Cookie";
    public override string CardText => "When your turn ends, set 1 card from your support area as active.《{G}{G}{G}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImagePath => "BS1_066.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}