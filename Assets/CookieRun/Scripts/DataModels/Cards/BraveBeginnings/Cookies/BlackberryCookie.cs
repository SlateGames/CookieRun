using UnityEngine;

public class BlackberryCookie : Card_Cookie
{
    public override string CardId => "77124";
    public override string CardNumber => "BS2-011";
    public override string CardName => "Blackberry Cookie";
    public override string CardText => "【Activate】 《{Y}{Y}》 Select {Y} Cookies from your break area until their total LV. sum reaches LV.3. Return those Cookies to your hand and place this Cookie into your break area.《{Y}{Y}{N}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_011.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;

    public BlackberryCookie()
    {
        Debug.Log("BlackberryCookie::BlackberryCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("BlackberryCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}