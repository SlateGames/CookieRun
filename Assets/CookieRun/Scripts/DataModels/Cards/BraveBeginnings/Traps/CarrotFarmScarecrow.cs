using UnityEngine;

public class CarrotFarmScarecrow : Card_Trap
{
    public override string CardId => "77148";
    public override string CardNumber => "BS2-021";
    public override string CardName => "Carrot Farm Scarecrow";
    public override string CardText => "《{G}》 Select up to 1 of your opponent's Cookies. During this turn, that Cookie deals -1 attack damage. Then, return 1 card from your support area to your hand. If you did, place 1 card from your hand into your support area as rested.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS2_021.png";

    public CarrotFarmScarecrow()
    {
        Debug.Log("CarrotFarmScarecrow::CarrotFarmScarecrow");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("CarrotFarmScarecrow::ActivateAbility");
        throw new System.NotImplementedException();
    }
}