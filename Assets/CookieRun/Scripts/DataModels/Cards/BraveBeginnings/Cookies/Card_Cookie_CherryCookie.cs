using UnityEngine;

public class Card_Cookie_CherryCookie : Card_Cookie
{
    public override string CardId => "77110";
    public override string CardNumber => "BS2-004";
    public override string CardName => "Cherry Cookie";
    public override string CardText => "《{R}》 Deals 1 damage. Then, 《can be used as {R}.》 If one of your opponent's Cookies is LV.1, deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS2_004.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;

    public Card_Cookie_CherryCookie()
    {
        Debug.Log("Card_Cookie_CherryCookie::Card_Cookie_CherryCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_CherryCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}