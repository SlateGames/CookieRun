using UnityEngine;

public class Card_Cookie_WindArcherCookie : Card_Cookie
{
    public override string CardId => "77244";
    public override string CardNumber => "BS2-058";
    public override string CardName => "Wind Archer Cookie";
    public override string CardText => "【On Play】 《{P}》 Place up to 1 of your opponent's LV.3 Cookies from their battle area into the trash.《{P}{P}{P}{P}》 Deals 4 damage. Then, if there are 15 cards or more in your trash, deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.UltraRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_058.png";
    public override int CardHealth => 5;
    public override int CardLevel => 3;

    public Card_Cookie_WindArcherCookie()
    {
        Debug.Log("Card_Cookie_WindArcherCookie::Card_Cookie_WindArcherCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_WindArcherCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}