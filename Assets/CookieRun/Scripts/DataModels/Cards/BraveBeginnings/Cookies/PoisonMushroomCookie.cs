using UnityEngine;

public class PoisonMushroomCookie : Card_Cookie
{
    public override string CardId => "77052";
    public override string CardNumber => "BS1-058";
    public override string CardName => "Poison Mushroom Cookie";
    public override string CardText => "When this Cookie faints, 《place 1 card from your support area into the trash.》 Deals 1 damage to all Cookies.《{G}{G}》 Deals 2 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_058.png";
    public override int CardHealth => 2;
    public override int CardLevel => 2;

    public PoisonMushroomCookie()
    {
        Debug.Log("PoisonMushroomCookie::PoisonMushroomCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("PoisonMushroomCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}