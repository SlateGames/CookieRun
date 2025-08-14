using UnityEngine;

public class GiantCherryBomb : Card_Item
{
    public override string CardId => "76960";
    public override string CardNumber => "BS1-022";
    public override string CardName => "Giant Cherry Bomb";
    public override string CardText => "《{R}{R}{R}》 《Discard 1 card.》 Select up to 1 of your opponent's Cookies. That Cookie receives 3 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_022.png";

    public GiantCherryBomb()
    {
        Debug.Log("GiantCherryBomb::GiantCherryBomb");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("GiantCherryBomb::ActivateAbility");
        throw new System.NotImplementedException();
    }
}