using UnityEngine;

public class Card_Cookie_WizardCookie : Card_Cookie
{
    public override string CardId => "77242";
    public override string CardNumber => "BS2-057";
    public override string CardName => "Wizard Cookie";
    public override string CardText => "【On Play】 《{P}》 Place up to 1 of your opponent's stage cards in the trash.《{P}{P}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_057.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;
}