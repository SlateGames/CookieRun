using UnityEngine;

public class Card_Cookie_HydrangeaCookie : Card_Cookie
{
    public override string CardId => "77252";
    public override string CardNumber => "BS2-061";
    public override string CardName => "Hydrangea Cookie";
    public override string CardText => "【On Play】 Select up to 3 cards from your trash that do not have FLIP. Return those cards to your deck and shuffle it.《{P}{P}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_061.png.webp";
    public override int CardHealth => 2;
    public override int CardLevel => 1;
}