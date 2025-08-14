using UnityEngine;

public class Card_Cookie_BellflowerCookie : Card_Cookie
{
    public override string CardId => "77050";
    public override string CardNumber => "BS1-057";
    public override string CardName => "Bellflower Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_057.png";
    public override int CardHealth => 4;
    public override int CardLevel => 1;

    public Card_Cookie_BellflowerCookie()
    {
        Debug.Log("Card_Cookie_BellflowerCookie::Card_Cookie_BellflowerCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_BellflowerCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}