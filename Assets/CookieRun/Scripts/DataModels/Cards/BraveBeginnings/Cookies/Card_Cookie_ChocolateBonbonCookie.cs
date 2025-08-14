using UnityEngine;

public class Card_Cookie_ChocolateBonbonCookie : Card_Cookie
{
    public override string CardId => "77196";
    public override string CardNumber => "BS2-037";
    public override string CardName => "Chocolate Bonbon Cookie";
    public override string CardText => "《{B}{B}{B}》 Deals 3 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_037.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;

    public Card_Cookie_ChocolateBonbonCookie()
    {
        Debug.Log("Card_Cookie_ChocolateBonbonCookie::Card_Cookie_ChocolateBonbonCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_ChocolateBonbonCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}