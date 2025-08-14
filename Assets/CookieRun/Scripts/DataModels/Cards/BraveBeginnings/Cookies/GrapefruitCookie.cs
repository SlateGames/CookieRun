using UnityEngine;

public class GrapefruitCookie : Card_Cookie
{
    public override string CardId => "77012";
    public override string CardNumber => "BS1-042";
    public override string CardName => "Grapefruit Cookie";
    public override string CardText => "When your opponent attacks this Cookie, 《can be used as {Y}.》 This Cookie receives -1 attack damage during this battle.《{Y}{Y}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_042.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public GrapefruitCookie()
    {
        Debug.Log("GrapefruitCookie::GrapefruitCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("GrapefruitCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}