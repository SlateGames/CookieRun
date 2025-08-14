using UnityEngine;

public class Card_Cookie_CauliflowerCookie : Card_Cookie
{
    public override string CardId => "77078";
    public override string CardNumber => "BS1-068";
    public override string CardName => "Cauliflower Cookie";
    public override string CardText => "【On Play】 《Place 1 card from your support area into the trash.》 Draw 1 card from your deck.《{G}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_068.png";
    public override int CardHealth => 4;
    public override int CardLevel => 2;

    public Card_Cookie_CauliflowerCookie()
    {
        Debug.Log("Card_Cookie_CauliflowerCookie::Card_Cookie_CauliflowerCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_CauliflowerCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}