using UnityEngine;

public class Card_Item_ForbiddenIncantation : Card_Item
{
    public override string CardId => "77300";
    public override string CardNumber => "BS2-077";
    public override string CardName => "Forbidden Incantation";
    public override string CardText => "《{P}{P}》 《Place 1 of your {P} LV.1 Cookies from your battle area into the trash.》 Select up to 1 of your opponent's Cookies. That Cookie receives 2 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_077.png";

    public Card_Item_ForbiddenIncantation()
    {
        Debug.Log("Card_Item_ForbiddenIncantation::Card_Item_ForbiddenIncantation");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Item_ForbiddenIncantation::ActivateAbility");
        throw new System.NotImplementedException();
    }
}