using UnityEngine;

public class MangoCookie : Card_Cookie
{
    public override string CardId => "77158";
    public override string CardNumber => "BS2-025";
    public override string CardName => "Mango Cookie";
    public override string CardText => "When this Cookie faints, you can draw 1 card from your deck. If you did, discard 1 card from your hand.《{B}{B}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_025.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;

    public MangoCookie()
    {
        Debug.Log("MangoCookie::MangoCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("MangoCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}