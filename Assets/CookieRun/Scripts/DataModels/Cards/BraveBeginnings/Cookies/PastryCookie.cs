using UnityEngine;

public class PastryCookie : Card_Cookie
{
    public override string CardId => "77288";
    public override string CardNumber => "BS2-072";
    public override string CardName => "Pastry Cookie";
    public override string CardText => "《{P}{P}{P}》 Deals 3 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_072.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;

    public PastryCookie()
    {
        Debug.Log("PastryCookie::PastryCookie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("PastryCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}