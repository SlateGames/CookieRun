using UnityEngine;

public class MuscleCookie : Card_Cookie
{
    public override string CardId => "77102";
    public override string CardNumber => "BS2-001";
    public override string CardName => "Muscle Cookie";
    public override string CardText => "《{R}{R}》 Deals 2 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS2_001.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public MuscleCookie()
    {
        Debug.Log("MuscleCookie::MuscleCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("MuscleCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}