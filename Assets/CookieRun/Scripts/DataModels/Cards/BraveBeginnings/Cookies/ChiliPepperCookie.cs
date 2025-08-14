using UnityEngine;

public class ChiliPepperCookie : Card_Cookie
{
    public override string CardId => "77112";
    public override string CardNumber => "BS2-005";
    public override string CardName => "Chili Pepper Cookie";
    public override string CardText => "《{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_005.png";
    public override int CardHealth => 1;
    public override int CardLevel => 3;

    public ChiliPepperCookie()
    {
        Debug.Log("ChiliPepperCookie::ChiliPepperCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("ChiliPepperCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}