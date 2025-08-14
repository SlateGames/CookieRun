using UnityEngine;

public class Card_Cookie_RockstarCookie : Card_Cookie
{
    public override string CardId => "76978";
    public override string CardNumber => "BS1-030";
    public override string CardName => "Rockstar Cookie";
    public override string CardText => "《{Y}{Y}》 Deals 2 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_030.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public Card_Cookie_RockstarCookie()
    {
        Debug.Log("Card_Cookie_RockstarCookie::Card_Cookie_RockstarCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_RockstarCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}