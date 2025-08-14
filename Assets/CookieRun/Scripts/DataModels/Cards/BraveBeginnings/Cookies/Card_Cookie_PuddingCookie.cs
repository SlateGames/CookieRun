using UnityEngine;

public class Card_Cookie_PuddingCookie : Card_Cookie
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

    public Card_Cookie_PuddingCookie()
    {
        Debug.Log("Card_Cookie_PuddingCookie::Card_Cookie_PuddingCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_PuddingCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}