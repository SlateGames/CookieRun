using UnityEngine;

public class GingerBrave : Card_Cookie
{
    public override string CardId => "76940";
    public override string CardNumber => "BS1-014";
    public override string CardName => "GingerBrave";
    public override string CardText => "【Activate】 【Once Per Turn】 《{R}{R}》 During this turn, this Cookie gains +1 attack damage.《{R}{R}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.UltraRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_014.png";
    public override int CardHealth => 2;
    public override int CardLevel => 1;

    public GingerBrave()
    {
        Debug.Log("GingerBrave::GingerBrave");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("GingerBrave::ActivateAbility");
        throw new System.NotImplementedException();
    }
}