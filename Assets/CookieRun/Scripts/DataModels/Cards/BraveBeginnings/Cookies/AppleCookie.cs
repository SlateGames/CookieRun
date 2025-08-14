using UnityEngine;

public class AppleCookie : Card_Cookie
{
    public override string CardId => "77022";
    public override string CardNumber => "BS1-046";
    public override string CardName => "Apple Cookie";
    public override string CardText => "《{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_046.png";
    public override int CardHealth => 1;
    public override int CardLevel => 3;

    public AppleCookie()
    {
        Debug.Log("AppleCookie::AppleCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("AppleCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}