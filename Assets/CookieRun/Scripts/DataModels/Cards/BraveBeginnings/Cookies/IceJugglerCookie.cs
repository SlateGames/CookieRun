using UnityEngine;

public class IceJugglerCookie : Card_Cookie
{
    public override string CardId => "76970";
    public override string CardNumber => "BS1-027";
    public override string CardName => "Ice Juggler Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_027.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;

    public IceJugglerCookie()
    {
        Debug.Log("IceJugglerCookie::IceJugglerCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("IceJugglerCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}