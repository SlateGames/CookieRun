using UnityEngine;

public class LemonThymeCookie : Card_Cookie
{
    public override string CardId => "77134";
    public override string CardNumber => "BS2-015";
    public override string CardName => "Lemon Thyme Cookie";
    public override string CardText => "【Activate】 《{G}{G}{G}{G}》 《Place this Cookie in the trash.》 Select up to 1 of your opponent's Cookies. That Cookie receives 2 damage. Then, take 1 card from the top of your deck and place it in your support area as rested.《{G}{G}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS2_015.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public LemonThymeCookie()
    {
        Debug.Log("LemonThymeCookie::LemonThymeCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
        CardAbility cardAbility03 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("LemonThymeCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}