using UnityEngine;

public class PuddingCookie : Card_Cookie
{
    public override string CardId => "77088";
    public override string CardNumber => "BS1-072";
    public override string CardName => "Pudding Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_072.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;

    public PuddingCookie()
    {
        Debug.Log("PuddingCookie::PuddingCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("PuddingCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}