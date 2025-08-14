using UnityEngine;

public class BananaCookie : Card_Cookie
{
    public override string CardId => "76984";
    public override string CardNumber => "BS1-032";
    public override string CardName => "Banana Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_032.png";
    public override int CardHealth => 4;
    public override int CardLevel => 1;

    public BananaCookie()
    {
        Debug.Log("BananaCookie::BananaCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("BananaCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}