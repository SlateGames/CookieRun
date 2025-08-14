using UnityEngine;

public class Card_Cookie_KumihoCookie : Card_Cookie
{
    public override string CardId => "76906";
    public override string CardNumber => "BS1-002";
    public override string CardName => "Kumiho Cookie";
    public override string CardText => "《{R}{R}{R}》 Deals 3 damage.FLIP 《Discard 1 card.》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_002.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;

    public Card_Cookie_KumihoCookie()
    {
        Debug.Log("Card_Cookie_KumihoCookie::Card_Cookie_KumihoCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_KumihoCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}