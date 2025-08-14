using UnityEngine;

public class WanderersApplePie : Card_Item
{
    public override string CardId => "77094";
    public override string CardNumber => "BS1-075";
    public override string CardName => "Wanderer's Apple Pie";
    public override string CardText => "《{G}{G}》 Place this card in your support area as rested.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_075.png";

    public WanderersApplePie()
    {
        Debug.Log("WanderersApplePie::WanderersApplePie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("WanderersApplePie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}