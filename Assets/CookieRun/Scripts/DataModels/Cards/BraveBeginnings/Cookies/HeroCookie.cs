using UnityEngine;

public class HeroCookie : Card_Cookie
{
    public override string CardId => "77298";
    public override string CardNumber => "BS2-076";
    public override string CardName => "Hero Cookie";
    public override string CardText => "《{N}{N}{N}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS2_076.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;

    public HeroCookie()
    {
        Debug.Log("HeroCookie::HeroCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("HeroCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}