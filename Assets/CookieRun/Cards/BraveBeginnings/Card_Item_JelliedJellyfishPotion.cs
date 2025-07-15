using UnityEngine;

public class Card_Item_JelliedJellyfishPotion : Card_Item
{
    public override string CardId => "77222";
    public override string CardNumber => "BS2-048";
    public override string CardName => "Jellied Jellyfish Potion";
    public override string CardText => "《{B}》 Draw up to 1 card for each of your opponent's Cookies that fainted during this turn.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_048.png.webp";
}