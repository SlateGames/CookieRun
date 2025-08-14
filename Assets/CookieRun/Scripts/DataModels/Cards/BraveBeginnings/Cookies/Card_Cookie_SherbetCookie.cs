using UnityEngine;

public class Card_Cookie_SherbetCookie : Card_Cookie
{
    public override string CardId => "77192";
    public override string CardNumber => "BS2-036";
    public override string CardName => "Sherbet Cookie";
    public override string CardText => "【On Play】 《Select 1 LV.1 Cookie from your battle area and return them to the bottom of your deck.》 You can draw 1 card from your deck.《{B}{B}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.UltraRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_036.png";
    public override int CardHealth => 5;
    public override int CardLevel => 2;

    public Card_Cookie_SherbetCookie()
    {
        Debug.Log("Card_Cookie_SherbetCookie::Card_Cookie_SherbetCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_SherbetCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}