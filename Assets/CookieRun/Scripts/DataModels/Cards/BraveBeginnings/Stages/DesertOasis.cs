using UnityEngine;

public class DesertOasis : Card_Stage
{
    public override string CardId => "76968";
    public override string CardNumber => "BS1-026";
    public override string CardName => "Desert Oasis";
    public override string CardText => "《{R}{R}》 Place in your stage area.\n【Activate】 《Rest this card.》 《Place 1 of your Cookies' HP cards in the trash.》 Select up to 1 of your Cookies. During this turn, that Cookie gains +1 attack damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Stage;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_026.png";

    public DesertOasis()
    {
        Debug.Log("DesertOasis::DesertOasis");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
        CardAbility cardAbility03 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("DesertOasis::ActivateAbility");
        throw new System.NotImplementedException();
    }
}