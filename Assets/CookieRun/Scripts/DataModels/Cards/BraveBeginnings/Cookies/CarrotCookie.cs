using UnityEngine;

public class CarrotCookie : Card_Cookie
{
    public override string CardId => "77120";
    public override string CardNumber => "BS2-009";
    public override string CardName => "Carrot Cookie";
    public override string CardText => "《{Y}{Y}》 Deals 2 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS2_009.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public CarrotCookie()
    {
        Debug.Log("CarrotCookie::CarrotCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("CarrotCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}