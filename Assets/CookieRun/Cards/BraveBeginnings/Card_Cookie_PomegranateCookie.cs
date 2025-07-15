using UnityEngine;

public class Card_Cookie_PomegranateCookie : Card_Cookie
{
    public override string CardId => "76922";
    public override string CardNumber => "BS1-008";
    public override string CardName => "Pomegranate Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《{R}》 Select up to 1 of your other Cookies. During this turn, that Cookie gains +1 attack damage.《{R}{R}{R}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS1_008.png.webp";
    public override int CardHealth => 5;
    public override int CardLevel => 2;
}