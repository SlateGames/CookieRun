using UnityEngine;

public class Card_Trap_BrokenSignpost : Card_Trap
{
    public override string CardId => "77030";
    public override string CardNumber => "BS1-050";
    public override string CardName => "Broken Signpost";
    public override string CardText => "《{Y}》 Redirect your opponent's attack to a different Cookie of your own.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_050.png";
}