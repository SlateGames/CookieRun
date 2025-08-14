using UnityEngine;

public class HerbCookie : Card_Cookie
{
    public override string CardId => "77090";
    public override string CardNumber => "BS1-073";
    public override string CardName => "Herb Cookie";
    public override string CardText => "【On Play】 《Place 1 card from your support area into the trash.》 Set 1 card from your support area as active.《{G}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_073.png";
    public override int CardHealth => 3;
    public override int CardLevel => 2;

    public HerbCookie()
    {
        Debug.Log("HerbCookie::HerbCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("HerbCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}