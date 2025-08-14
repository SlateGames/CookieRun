using UnityEngine;

public class Card_Cookie_CroissantCookie : Card_Cookie
{
    public override string CardId => "76948";
    public override string CardNumber => "BS1-017";
    public override string CardName => "Croissant Cookie";
    public override string CardText => "【On Play】 《{R}{R}》 Select up to 1 of your other Cookies. During this turn, that Cookie gains +2 attack damage.《{R}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_017.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;

    public Card_Cookie_CroissantCookie()
    {
        Debug.Log("Card_Cookie_CroissantCookie::Card_Cookie_CroissantCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_CroissantCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}