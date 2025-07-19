using UnityEngine;

public class Card_Trap_HermitCrabsShell : Card_Trap
{
    public override string CardId => "77226";
    public override string CardNumber => "BS2-050";
    public override string CardName => "Hermit Crab's Shell";
    public override string CardText => "《{B}{B}{B}》 《Discard 1 card.》 Select up to 1 of your opponent's Cookies whose remaining HP is 3 or less and place them at the bottom of the deck.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_050.png";
}