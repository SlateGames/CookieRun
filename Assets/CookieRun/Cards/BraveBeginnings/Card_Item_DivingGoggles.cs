using UnityEngine;

public class Card_Item_DivingGoggles : Card_Item
{
    public override string CardId => "77220";
    public override string CardNumber => "BS2-047";
    public override string CardName => "Diving Goggles";
    public override string CardText => "《{B}{B}{B}》 《Discard 3 cards.》 Select up to 2 of your opponent's Cookies. Deals 2 damage to each of those Cookies.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_047.png";
}