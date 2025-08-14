using UnityEngine;

public class Card_Cookie_TimekeeperCookie : Card_Cookie
{
    public override string CardId => "76998";
    public override string CardNumber => "BS1-037";
    public override string CardName => "Timekeeper Cookie";
    public override string CardText => "【On Play】 《Discard 1 card.》 《{Y}{Y}》 Select up to 1 LV.2 or lower Cookie from your break area. Place that Cookie in the trash.《{Y}{Y}{Y}》 Deals 3 damage. Then, 《can be used as {Y}.》 Select up to 1 of your opponent's LV.1 Cookies. Place that Cookie in the break area.";
    public override CardRarity CardRarity => CardRarity.UltraRare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_037.png";
    public override int CardHealth => 5;
    public override int CardLevel => 3;

    public Card_Cookie_TimekeeperCookie()
    {
        Debug.Log("Card_Cookie_TimekeeperCookie::Card_Cookie_TimekeeperCookie");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
        CardAbility cardAbility03 = new CardAbility();
        CardAbility cardAbility04 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_TimekeeperCookie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}