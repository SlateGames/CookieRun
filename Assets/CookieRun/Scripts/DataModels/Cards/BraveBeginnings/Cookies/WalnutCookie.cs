using UnityEngine;

public class WalnutCookie : Card_Cookie
{
    public override string CardId => "76954";
    public override string CardNumber => "BS1-019";
    public override string CardName => "Walnut Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_019.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;

    public WalnutCookie()
    {
        Debug.Log("WalnutCookie::WalnutCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("WalnutCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}