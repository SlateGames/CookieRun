using UnityEngine;

public class RebelCookie : Card_Cookie
{
    public override string CardId => "77106";
    public override string CardNumber => "BS2-003";
    public override string CardName => "Rebel Cookie";
    public override string CardText => "【On Play】 《{R}{R}》 Select up to 1 of your opponent's Cookies. That Cookie receives 2 damage.《{R}{R}{R}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS2_003.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;

    public RebelCookie()
    {
        Debug.Log("RebelCookie::RebelCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("RebelCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}