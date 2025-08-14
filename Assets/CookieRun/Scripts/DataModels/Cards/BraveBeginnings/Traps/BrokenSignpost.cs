using UnityEngine;

public class BrokenSignpost : Card_Trap
{
    public override string CardId => "77030";
    public override string CardNumber => "BS1-050";
    public override string CardName => "Broken Signpost";
    public override string CardText => "《{Y}》 Redirect your opponent's attack to a different Cookie of your own.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_050.png";

    public BrokenSignpost()
    {
        Debug.Log("BrokenSignpost::BrokenSignpost");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("BrokenSignpost::ActivateAbility");
        throw new System.NotImplementedException();
    }
}