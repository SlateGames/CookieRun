using UnityEngine;

public class Card_Item_PricklyCactiGloves : Card_Item
{
    public override string CardId => "77114";
    public override string CardNumber => "BS2-006";
    public override string CardName => "Prickly Cacti Gloves";
    public override string CardText => "《{R}{R}》 Select up to 1 of your opponent's Cookies. That Cookie receives 2 damage. Then, select 1 of your Cookies and place 2 of their HP cards in the trash.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS2_006.png.webp";
}