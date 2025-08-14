using UnityEngine;

public class BlueberryPieCookie : Card_Cookie
{
    public override string CardId => "77182";
    public override string CardNumber => "BS2-032";
    public override string CardName => "Blueberry Pie Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_032.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;

    public BlueberryPieCookie()
    {
        Debug.Log("BlueberryPieCookie::BlueberryPieCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("BlueberryPieCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}