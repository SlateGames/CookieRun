using UnityEngine;

public class PlumCookie : Card_Cookie
{
    public override string CardId => "77068";
    public override string CardNumber => "BS1-065";
    public override string CardName => "Plum Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_065.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;

    public PlumCookie()
    {
        Debug.Log("PlumCookie::PlumCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("PlumCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}