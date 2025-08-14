using UnityEngine;

public class PurpleYamCookie : Card_Cookie
{
    public override string CardId => "77266";
    public override string CardNumber => "BS2-065";
    public override string CardName => "Purple Yam Cookie";
    public override string CardText => "【On Play】 《{P}》 Place up to 1 of your opponent's stage cards in the trash.《{P}{P}{P}{P}》 Deals 4 damage.";
    public override CardRarity CardRarity => CardRarity.Common;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_065.png";
    public override int CardHealth => 5;
    public override int CardLevel => 3;

    public PurpleYamCookie()
    {
        Debug.Log("PurpleYamCookie::PurpleYamCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("PurpleYamCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}