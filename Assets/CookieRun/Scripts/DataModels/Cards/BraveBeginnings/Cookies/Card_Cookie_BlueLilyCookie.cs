using UnityEngine;

public class Card_Cookie_BlueLilyCookie : Card_Cookie
{
    public override string CardId => "77040";
    public override string CardNumber => "BS1-054";
    public override string CardName => "Blue Lily Cookie";
    public override string CardText => "{mt} 【On Play】 《Place 1 card from your support area in the trash.》 Deals 1 damage to all of your opponent's Cookies.《{G}{G}{G}{G}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_054.png";
    public override int CardHealth => 5;
    public override int CardLevel => 3;

    public Card_Cookie_BlueLilyCookie()
    {
        Debug.Log("Card_Cookie_BlueLilyCookie::Card_Cookie_BlueLilyCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_BlueLilyCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}