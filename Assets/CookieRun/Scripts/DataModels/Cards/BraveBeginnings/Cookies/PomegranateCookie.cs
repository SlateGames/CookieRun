using UnityEngine;

public class PomegranateCookie : Card_Cookie
{
    public override string CardId => "76922";
    public override string CardNumber => "BS1-008";
    public override string CardName => "Pomegranate Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《{R}》 Select up to 1 of your other Cookies. During this turn, that Cookie gains +1 attack damage.《{R}{R}{R}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_008.png";
    public override int CardHealth => 5;
    public override int CardLevel => 2;

    public PomegranateCookie()
    {
        Debug.Log("PomegranateCookie::PomegranateCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("PomegranateCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}