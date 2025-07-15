using UnityEngine;

public class Card_Cookie_MarshmallowCookie : Card_Cookie
{
    public override string CardId => "76980";
    public override string CardNumber => "BS1-031";
    public override string CardName => "Marshmallow Cookie";
    public override string CardText => "【Blocker】 《{Y}》 (When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.)《{Y}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS1_031.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}