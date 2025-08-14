using UnityEngine;

public class Card_Cookie_MoonRabbitCookie : Card_Cookie
{
    public override string CardId => "77046";
    public override string CardNumber => "BS1-056";
    public override string CardName => "Moon Rabbit Cookie";
    public override string CardText => "【On Play】 《{G}{G}》 Select up to 1 of your other LV.2 or lower Cookies from your battle area. Place them in your support area as active.《{G}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_056.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;

    public Card_Cookie_MoonRabbitCookie()
    {
        Debug.Log("Card_Cookie_MoonRabbitCookie::Card_Cookie_MoonRabbitCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_MoonRabbitCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}