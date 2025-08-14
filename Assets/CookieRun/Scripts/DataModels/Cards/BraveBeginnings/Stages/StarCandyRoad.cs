using UnityEngine;

public class StarCandyRoad : Card_Stage
{
    public override string CardId => "77034";
    public override string CardNumber => "BS1-052";
    public override string CardName => "Star Candy Road";
    public override string CardText => "《{Y}》 Place in your stage area.\n【Activate】 《{Y}{Y}》 《Rest this card.》 Select 1 of your Cookies. That Cookie gains +1 HP.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Stage;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_052.png";

    public StarCandyRoad()
    {
        Debug.Log("StarCandyRoad::StarCandyRoad");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
        CardAbility cardAbility03 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("StarCandyRoad::ActivateAbility");
        throw new System.NotImplementedException();
    }
}