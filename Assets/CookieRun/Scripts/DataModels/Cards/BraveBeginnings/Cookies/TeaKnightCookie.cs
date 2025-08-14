using UnityEngine;

public class TeaKnightCookie : Card_Cookie
{
    public override string CardId => "77060";
    public override string CardNumber => "BS1-062";
    public override string CardName => "Tea Knight Cookie";
    public override string CardText => "【Blocker】 《{G}》 (When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.)《{G}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Invalid;
    public override string ImageName => "BS1_062.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;

    public TeaKnightCookie()
    {
        Debug.Log("TeaKnightCookie::TeaKnightCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("TeaKnightCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}