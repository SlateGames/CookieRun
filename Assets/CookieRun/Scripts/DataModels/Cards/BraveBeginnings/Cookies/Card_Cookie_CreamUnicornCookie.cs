using UnityEngine;

public class Card_Cookie_CreamUnicornCookie : Card_Cookie
{
    public override string CardId => "77274";
    public override string CardNumber => "BS2-068";
    public override string CardName => "Cream Unicorn Cookie";
    public override string CardText => "【On Play】 《Discard 1 card.》 Return up to 1 {P} card from your trash to your hand.《{P}{P}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_068.png";
    public override int CardHealth => 5;
    public override int CardLevel => 2;

    public Card_Cookie_CreamUnicornCookie()
    {
        Debug.Log("Card_Cookie_CreamUnicornCookie::Card_Cookie_CreamUnicornCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_CreamUnicornCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}