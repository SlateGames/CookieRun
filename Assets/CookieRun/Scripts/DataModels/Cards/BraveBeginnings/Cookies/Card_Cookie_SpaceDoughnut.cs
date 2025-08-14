using UnityEngine;

public class Card_Cookie_SpaceDoughnut : Card_Cookie
{
    public override string CardId => "77260";
    public override string CardNumber => "BS2-063";
    public override string CardName => "Space Doughnut";
    public override string CardText => "《{P}{P}{P}》 Deals 3 damage.FLIP 《Discard 1 card.》 If your break area is LV.3 or higher, place either 1 of your opponent's Cookies that is LV.2 or lower from their battle area or 1 stage card from their stage area into the trash.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_063.png";
    public override int CardHealth => 3;
    public override int CardLevel => 3;

    public Card_Cookie_SpaceDoughnut()
    {
        Debug.Log("Card_Cookie_SpaceDoughnut::Card_Cookie_SpaceDoughnut");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Cookie_SpaceDoughnut::ActivateAbility");
        throw new System.NotImplementedException();
    }
}