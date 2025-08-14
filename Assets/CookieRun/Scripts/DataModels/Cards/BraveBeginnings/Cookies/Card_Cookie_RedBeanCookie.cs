using UnityEngine;

public class Card_Cookie_RedBeanCookie : Card_Cookie
{
    public override string CardId => "77044";
    public override string CardNumber => "BS1-055";
    public override string CardName => "Red Bean Cookie";
    public override string CardText => "《{G}{G}》 Deals 2 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_055.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public Card_Cookie_RedBeanCookie()
    {
        Debug.Log("Card_Cookie_RedBeanCookie::Card_Cookie_RedBeanCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_RedBeanCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}