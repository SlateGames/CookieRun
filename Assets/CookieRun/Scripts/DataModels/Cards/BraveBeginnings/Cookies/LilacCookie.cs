using UnityEngine;

public class LilacCookie : Card_Cookie
{
    public override string CardId => "76914";
    public override string CardNumber => "BS1-004";
    public override string CardName => "Lilac Cookie";
    public override string CardText => "【Activate】 《{R}{R}》 Return this Cookie to your hand.《{R}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_004.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;

    public LilacCookie()
    {
        Debug.Log("LilacCookie::LilacCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("LilacCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}