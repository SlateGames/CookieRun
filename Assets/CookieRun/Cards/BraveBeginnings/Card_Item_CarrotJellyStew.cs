using UnityEngine;

public class Card_Item_CarrotJellyStew : Card_Item
{
    public override string CardId => "77146";
    public override string CardNumber => "BS2-020";
    public override string CardName => "Carrot Jelly Stew";
    public override string CardText => "《{G}{G}》 Select up to 1 of your {G} Cookies. Place 1 of their attached HP cards in your support area as rested.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImagePath => "BS2_020.png.webp";
}