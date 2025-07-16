using UnityEngine;

public class Card_Cookie_RaspberryMousseCookie : Card_Cookie
{
    public override string CardId => "77240";
    public override string CardNumber => "BS2-056";
    public override string CardName => "Raspberry Mousse Cookie";
    public override string CardText => "《{P}》 Deals 1 damage.FLIP 《Discard 1 card.》 The Cookie with this card attached for HP gains +1 HP.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_056.png";
    public override int CardHealth => 1;
    public override int CardLevel => 1;
}