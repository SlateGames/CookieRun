using UnityEngine;

public class Card_Cookie_AffogatoCookie : Card_Cookie
{
    public override string CardId => "76926";
    public override string CardNumber => "BS1-009";
    public override string CardName => "Affogato Cookie";
    public override string CardText => "【Blocker】 《{R}》 (When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.)《{R}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_009.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}