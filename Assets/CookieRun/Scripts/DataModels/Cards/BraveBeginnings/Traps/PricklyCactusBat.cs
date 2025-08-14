using UnityEngine;

public class PricklyCactusBat : Card_Trap
{
    public override string CardId => "77116";
    public override string CardNumber => "BS2-007";
    public override string CardName => "Prickly Cactus Bat";
    public override string CardText => "《{R}》 《Discard 1 {R} card.》 Select up to 1 of your opponent's LV.1 Cookies. That Cookie receives 2 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS2_007.png";

    public PricklyCactusBat()
    {
        Debug.Log("PricklyCactusBat::PricklyCactusBat");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("PricklyCactusBat::ActivateAbility");
        throw new System.NotImplementedException();
    }
}