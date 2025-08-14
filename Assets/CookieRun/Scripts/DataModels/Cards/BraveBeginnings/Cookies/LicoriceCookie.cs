using UnityEngine;

public class LicoriceCookie : Card_Cookie
{
    public override string CardId => "77150";
    public override string CardNumber => "BS2-022";
    public override string CardName => "Licorice Cookie";
    public override string CardText => "【On Play】 This Cookie takes no damage from effects until the start of the player's next turn.《{B}{B}{B}》 Deals 3 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_022.png";
    public override int CardHealth => 4;
    public override int CardLevel => 3;

    public LicoriceCookie()
    {
        Debug.Log("LicoriceCookie::LicoriceCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("LicoriceCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}