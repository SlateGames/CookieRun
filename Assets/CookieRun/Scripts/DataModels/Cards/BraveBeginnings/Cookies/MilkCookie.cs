using UnityEngine;

public class MilkCookie : Card_Cookie
{
    public override string CardId => "77208";
    public override string CardNumber => "BS2-042";
    public override string CardName => "Milk Cookie";
    public override string CardText => "《{B}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_042.png";
    public override int CardHealth => 1;
    public override int CardLevel => 1;

    public MilkCookie()
    {
        Debug.Log("MilkCookie::MilkCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("MilkCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}