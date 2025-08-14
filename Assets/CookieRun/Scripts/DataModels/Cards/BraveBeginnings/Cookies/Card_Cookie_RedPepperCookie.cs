using UnityEngine;

public class Card_Cookie_RedPepperCookie : Card_Cookie
{
    public override string CardId => "76956";
    public override string CardNumber => "BS1-020";
    public override string CardName => "Red Pepper Cookie";
    public override string CardText => "《{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_020.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;

    public Card_Cookie_RedPepperCookie()
    {
        Debug.Log("Card_Cookie_RedPepperCookie::Card_Cookie_RedPepperCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_RedPepperCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}