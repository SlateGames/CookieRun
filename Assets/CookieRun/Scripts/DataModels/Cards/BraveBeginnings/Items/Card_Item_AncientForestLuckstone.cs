using UnityEngine;

public class Card_Item_AncientForestLuckstone : Card_Item
{
    public override string CardId => "77092";
    public override string CardNumber => "BS1-074";
    public override string CardName => "Ancient Forest Luckstone";
    public override string CardText => "《{G}》 《Return 1 card from your support area to your hand.》 You can draw 1 card from your deck.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImageName => "BS1_074.png";

    public Card_Item_AncientForestLuckstone()
    {
        Debug.Log("Card_Item_AncientForestLuckstone::Card_Item_AncientForestLuckstone");
        CardAbility cardAbility01 = new CardAbility();
        CardAbility cardAbility02 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Item_AncientForestLuckstone::ActivateAbility");
        throw new System.NotImplementedException();
    }
}