using UnityEngine;

public class SpicyPowerJuice : Card_Item
{
    public override string CardId => "76962";
    public override string CardNumber => "BS1-023";
    public override string CardName => "Spicy Power Juice";
    public override string CardText => "《{R}》 《Place 1 of your Cookies' HP cards in the trash until the Cookie's HP reaches 1.》 Select up to 1 of your Cookies. During this turn, that Cookie gains +2 attack damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_023.png";

    public SpicyPowerJuice()
    {
        Debug.Log("SpicyPowerJuice::SpicyPowerJuice");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("SpicyPowerJuice::ActivateAbility");
        throw new System.NotImplementedException();
    }
}