using UnityEngine;

public class Card_Stage_AwakeningAncientForest : Card_Stage
{
    public override string CardId => "77100";
    public override string CardNumber => "BS1-078";
    public override string CardName => "Awakening Ancient Forest";
    public override string CardText => "《{G}》 Place in your stage area.\n【Activate】 《Rest this card.》 If the number of cards in your support area has decreased during this turn, set 1 card from your support area as active.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Stage;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_078.png";
}