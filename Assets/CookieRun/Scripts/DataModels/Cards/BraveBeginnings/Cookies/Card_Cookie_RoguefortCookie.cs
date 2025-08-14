using UnityEngine;

public class Card_Cookie_RoguefortCookie : Card_Cookie
{
    public override string CardId => "77036";
    public override string CardNumber => "BS1-053";
    public override string CardName => "Roguefort Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《{G}》 If there are 6 cards or less in your hand, return 1 card from your support area to your hand. Then, take 1 card from the top of your deck and place it in your support area as rested.《{G}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.UltraRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_053.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;

    public Card_Cookie_RoguefortCookie()
    {
        Debug.Log("Card_Cookie_RoguefortCookie::Card_Cookie_RoguefortCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_RoguefortCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}