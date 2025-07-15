using UnityEngine;

public class Card_Cookie_TeaKnightCookie : Card_Cookie
{
    public override string CardId => "77060";
    public override string CardNumber => "BS1-062";
    public override string CardName => "Tea Knight Cookie";
    public override string CardText => "【Blocker】 《{G}》 (When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.)《{G}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_062.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}