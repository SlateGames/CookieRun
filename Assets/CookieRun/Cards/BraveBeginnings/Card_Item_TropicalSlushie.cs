using UnityEngine;

public class Card_Item_TropicalSlushie : Card_Item
{
    public override string CardId => "77028";
    public override string CardNumber => "BS1-049";
    public override string CardName => "Tropical Slushie";
    public override string CardText => "《{Y}{Y}》 Deals 1 damage for each 1 {Y} LV.2 or higher Cookie in your break area to 1 of your opponent's Cookies.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_049.png.webp";
}