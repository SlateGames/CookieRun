using UnityEngine;

public class Card_Cookie_EggnogCookie : Card_Cookie
{
    public override string CardId => "77206";
    public override string CardNumber => "BS2-041";
    public override string CardName => "Eggnog Cookie";
    public override string CardText => "《{N}{N}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_041.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public Card_Cookie_EggnogCookie()
    {
        Debug.Log("Card_Cookie_EggnogCookie::Card_Cookie_EggnogCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_EggnogCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}