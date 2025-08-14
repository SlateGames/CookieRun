using UnityEngine;

public class CaptainIceCookie : Card_Cookie
{
    public override string CardId => "77210";
    public override string CardNumber => "BS2-043";
    public override string CardName => "Captain Ice Cookie";
    public override string CardText => "When this Cookie faints, 《discard 2 cards.》 Select up to 2 of your opponent's Cookies. Deals 1 damage to each of those Cookies.《{B}{B}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_043.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public CaptainIceCookie()
    {
        Debug.Log("CaptainIceCookie::CaptainIceCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("CaptainIceCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}