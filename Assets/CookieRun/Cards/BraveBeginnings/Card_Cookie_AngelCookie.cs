using UnityEngine;

public class Card_Cookie_AngelCookie : Card_Cookie
{
    public override string CardId => "77270";
    public override string CardNumber => "BS2-067";
    public override string CardName => "Angel Cookie";
    public override string CardText => "【Blocker】 《{P}》 (When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.)《{P}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImagePath => "BS2_067.png.webp";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}