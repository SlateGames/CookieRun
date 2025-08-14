using UnityEngine;

public class Card_Cookie_DinoSourCookie : Card_Cookie
{
    public override string CardId => "77234";
    public override string CardNumber => "BS2-054";
    public override string CardName => "Dino-Sour Cookie";
    public override string CardText => "《{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_054.png";
    public override int CardHealth => 1;
    public override int CardLevel => 3;

    public Card_Cookie_DinoSourCookie()
    {
        Debug.Log("Card_Cookie_DinoSourCookie::Card_Cookie_DinoSourCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_DinoSourCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}