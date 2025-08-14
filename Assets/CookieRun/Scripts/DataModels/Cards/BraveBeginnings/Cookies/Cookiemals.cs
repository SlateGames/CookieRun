using UnityEngine;

public class Cookiemals : Card_Cookie
{
    public override string CardId => "77080";
    public override string CardNumber => "BS1-069";
    public override string CardName => "Cookiemals";
    public override string CardText => "《{G}》 Deals 1 damage.FLIP Draw up to 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_069.png";
    public override int CardHealth => 1;
    public override int CardLevel => 1;

    public Cookiemals()
    {
        Debug.Log("Cookiemals::Cookiemals");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Cookiemals::ActivateAbility");
        throw new System.NotImplementedException();
    }
}