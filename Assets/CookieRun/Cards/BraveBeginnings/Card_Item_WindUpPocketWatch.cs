using UnityEngine;

public class Card_Item_WindUpPocketWatch : Card_Item
{
    public override string CardId => "77130";
    public override string CardNumber => "BS2-013";
    public override string CardName => "Wind-Up Pocket Watch";
    public override string CardText => "《{Y}{Y}》 Place 1 Cookie from your battle area into your break area, then play up to 1 LV.1 Cookie from your break area.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS2_013.png.webp";
}