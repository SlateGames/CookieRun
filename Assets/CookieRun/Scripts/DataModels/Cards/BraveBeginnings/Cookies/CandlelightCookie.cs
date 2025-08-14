using UnityEngine;

public class CandlelightCookie : Card_Cookie
{
    public override string CardId => "77142";
    public override string CardNumber => "BS2-018";
    public override string CardName => "Candlelight Cookie";
    public override string CardText => "【On Play】 《{G}》 Place up to 1 of your opponent's stage cards in the trash.《{G}{G}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS2_018.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;

    public CandlelightCookie()
    {
        Debug.Log("CandlelightCookie::CandlelightCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("CandlelightCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}