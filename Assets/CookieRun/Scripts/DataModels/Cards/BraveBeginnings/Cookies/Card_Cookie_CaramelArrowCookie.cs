using UnityEngine;

public class Card_Cookie_CaramelArrowCookie : Card_Cookie
{
    public override string CardId => "77218";
    public override string CardNumber => "BS2-046";
    public override string CardName => "Caramel Arrow Cookie";
    public override string CardText => "【On Play】 《{B}》 Place up to 1 of your opponent's stage cards in the trash.《{B}{B}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_046.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;

    public Card_Cookie_CaramelArrowCookie()
    {
        Debug.Log("Card_Cookie_CaramelArrowCookie::Card_Cookie_CaramelArrowCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_CaramelArrowCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}