using UnityEngine;

public class Card_Cookie_SorbetSharkCookie : Card_Cookie
{
    public override string CardId => "77184";
    public override string CardNumber => "BS2-033";
    public override string CardName => "Sorbet Shark Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《Discard 1 card.》 Set this Cookie as active.《{B}{B}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_033.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;

    public Card_Cookie_SorbetSharkCookie()
    {
        Debug.Log("Card_Cookie_SorbetSharkCookie::Card_Cookie_SorbetSharkCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_SorbetSharkCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}