using UnityEngine;

public class WildberryCookie : Card_Cookie
{
    public override string CardId => "76934";
    public override string CardNumber => "BS1-012";
    public override string CardName => "Wildberry Cookie";
    public override string CardText => "If your break area is LV.9, this Cookie gains +2 attack damage.《{R}{R}{R}{R}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_012.png";
    public override int CardHealth => 6;
    public override int CardLevel => 3;

    public WildberryCookie()
    {
        Debug.Log("WildberryCookie::WildberryCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("WildberryCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}