using UnityEngine;

public class Card_Cookie_PeperoncinoCookie : Card_Cookie
{
    public override string CardId => "77290";
    public override string CardNumber => "BS2-073";
    public override string CardName => "Peperoncino Cookie";
    public override string CardText => "If there are 15 cards or more in your trash, this Cookie deals +2 attack damage.《{P}{P}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_073.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;
}