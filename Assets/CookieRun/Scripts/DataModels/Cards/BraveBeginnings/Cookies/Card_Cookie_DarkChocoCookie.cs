using UnityEngine;

public class Card_Cookie_DarkChocoCookie : Card_Cookie
{
    public override string CardId => "76910";
    public override string CardNumber => "BS1-003";
    public override string CardName => "Dark Choco Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《{R}》 《Discard 1 card.》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.《{R}{R}{R}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_003.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;

    public Card_Cookie_DarkChocoCookie()
    {
        Debug.Log("Card_Cookie_DarkChocoCookie::Card_Cookie_DarkChocoCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
        CardAbility cardAbility03 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_DarkChocoCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}