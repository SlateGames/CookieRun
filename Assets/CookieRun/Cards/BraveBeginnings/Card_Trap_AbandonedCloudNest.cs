using UnityEngine;

public class Card_Trap_AbandonedCloudNest : Card_Trap
{
    public override string CardId => "77306";
    public override string CardNumber => "BS2-080";
    public override string CardName => "Abandoned Cloud Nest";
    public override string CardText => "《{P}{P}》 If there are 15 cards or more in your trash, select up to 1 of your opponent's Cookies. During this turn, that Cookie deals -3 attack damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_080.png";
}