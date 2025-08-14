using UnityEngine;

public class CreamUnicornCookie : Card_Cookie
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

    public CreamUnicornCookie()
    {
        Debug.Log("CreamUnicornCookie::CreamUnicornCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("CreamUnicornCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}