using UnityEngine;

public class Card_Cookie_PastryCookie : Card_Cookie
{
    public override string CardId => "77288";
    public override string CardNumber => "BS2-072";
    public override string CardName => "Pastry Cookie";
    public override string CardText => "《{P}{P}{P}》 Deals 3 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_072.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;
}