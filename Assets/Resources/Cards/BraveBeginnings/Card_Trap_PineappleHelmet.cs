using UnityEngine;

public class Card_Trap_PineappleHelmet : Card_Trap
{
    public override string CardId => "76966";
    public override string CardNumber => "BS1-025";
    public override string CardName => "Pineapple Helmet";
    public override string CardText => "《{R}》 If 1 of your Cookies has 1 HP, select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_025.png";
}