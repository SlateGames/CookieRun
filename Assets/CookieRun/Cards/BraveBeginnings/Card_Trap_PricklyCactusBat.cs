using UnityEngine;

public class Card_Trap_PricklyCactusBat : Card_Trap
{
    public override string CardId => "77116";
    public override string CardNumber => "BS2-007";
    public override string CardName => "Prickly Cactus Bat";
    public override string CardText => "《{R}》 《Discard 1 {R} card.》 Select up to 1 of your opponent's LV.1 Cookies. That Cookie receives 2 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS2_007.png";
}