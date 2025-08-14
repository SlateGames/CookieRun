using UnityEngine;

public class ErraticYakgwaRobot : Card_Trap
{
    public override string CardId => "77132";
    public override string CardNumber => "BS2-014";
    public override string CardName => "Erratic Yakgwa Robot";
    public override string CardText => "《{Y}》 Select up to 1 of your opponent's Cookies. During this turn, that Cookie deals -1 attack damage. Then, you can return 1 LV.1 Cookie from your break area to your hand. If you did, place 1 Cookie from your hand into your break area.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS2_014.png";

    public ErraticYakgwaRobot()
    {
        Debug.Log("ErraticYakgwaRobot::ErraticYakgwaRobot");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("ErraticYakgwaRobot::ActivateAbility");
        throw new System.NotImplementedException();
    }
}