using UnityEngine;

public class FigCookie : Card_Cookie
{
    public override string CardId => "77054";
    public override string CardNumber => "BS1-059";
    public override string CardName => "Fig Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_059.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;

    public FigCookie()
    {
        Debug.Log("FigCookie::FigCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("FigCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}