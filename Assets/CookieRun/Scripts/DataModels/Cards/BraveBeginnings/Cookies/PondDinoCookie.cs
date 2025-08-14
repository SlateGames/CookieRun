using UnityEngine;

public class PondDinoCookie : Card_Cookie
{
    public override string CardId => "77168";
    public override string CardNumber => "BS2-028";
    public override string CardName => "Pond Dino Cookie";
    public override string CardText => "【Activate】 【Once Per Turn】 《Discard 1 card.》 During this turn, your opponent cannot activate 【Blocker】.《{B}{B}{B}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.SuperRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_028.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;

    public PondDinoCookie()
    {
        Debug.Log("PondDinoCookie::PondDinoCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("PondDinoCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}