using UnityEngine;

public class Card_Cookie_PondDinoCookie : Card_Cookie
{
    public override string CardId => "77168";
    public override string CardNumber => "BS2-028";
    public override string CardName => "Pond Dino Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《Discard 1 card.》 During this turn, your opponent cannot activate 【Blocker】.《{B}{B}{B}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_028.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}