using UnityEngine;

public class Card_Cookie_CottonCandyCookie : Card_Cookie
{
    public override string CardId => "76992";
    public override string CardNumber => "BS1-035";
    public override string CardName => "Cotton Candy Cookie";
    public override string CardText => "When this Cookie faints, 《can be used as {Y}.》 Select up to 1 LV.1 Cookie in your break area. Place that Cookie in the trash.《{Y}{Y}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_035.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public Card_Cookie_CottonCandyCookie()
    {
        Debug.Log("Card_Cookie_CottonCandyCookie::Card_Cookie_CottonCandyCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_CottonCandyCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}