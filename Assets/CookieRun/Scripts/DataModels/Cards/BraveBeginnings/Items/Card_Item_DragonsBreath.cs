using UnityEngine;

public class Card_Item_DragonsBreath : Card_Item
{
    public override string CardId => "77302";
    public override string CardNumber => "BS2-078";
    public override string CardName => "Dragon's Breath";
    public override string CardText => "《{P}{P}{P}》 Place 1 Cookie that is LV.2 or lower from your battle area into the trash.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImageName => "BS2_078.png";

    public Card_Item_DragonsBreath()
    {
        Debug.Log("Card_Item_DragonsBreath::Card_Item_DragonsBreath");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Item_DragonsBreath::ActivateAbility");
        throw new System.NotImplementedException();
    }
}