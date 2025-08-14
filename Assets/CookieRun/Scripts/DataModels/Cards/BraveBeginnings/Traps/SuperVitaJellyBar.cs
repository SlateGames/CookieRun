using UnityEngine;

public class SuperVitaJellyBar : Card_Trap
{
    public override string CardId => "77032";
    public override string CardNumber => "BS1-051";
    public override string CardName => "Super-Vita Jelly Bar";
    public override string CardText => "《{Y}》 Select up to 1 of your Cookies. That Cookie gains +1 HP.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_051.png";

    public SuperVitaJellyBar()
    {
        Debug.Log("SuperVitaJellyBar::SuperVitaJellyBar");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("SuperVitaJellyBar::ActivateAbility");
        throw new System.NotImplementedException();
    }
}