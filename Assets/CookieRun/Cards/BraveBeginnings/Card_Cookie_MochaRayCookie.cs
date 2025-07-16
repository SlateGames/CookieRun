using UnityEngine;

public class Card_Cookie_MochaRayCookie : Card_Cookie
{
    public override string CardId => "77160";
    public override string CardNumber => "BS2-026";
    public override string CardName => "Mocha Ray Cookie";
    public override string CardText => "【Blocker】 《{B}》 (When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.)《{B}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_026.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}