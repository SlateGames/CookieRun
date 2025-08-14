using UnityEngine;

public class RaspberryMousseCookie : Card_Cookie
{
    public override string CardId => "77240";
    public override string CardNumber => "BS2-056";
    public override string CardName => "Raspberry Mousse Cookie";
    public override string CardText => "《{P}》 Deals 1 damage.FLIP 《Discard 1 card.》 The Cookie with this card attached for HP gains +1 HP.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_056.png";
    public override int CardHealth => 1;
    public override int CardLevel => 1;

    public RaspberryMousseCookie()
    {
        Debug.Log("RaspberryMousseCookie::RaspberryMousseCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("RaspberryMousseCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}