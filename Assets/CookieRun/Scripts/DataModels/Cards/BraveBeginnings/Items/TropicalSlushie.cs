using UnityEngine;

public class TropicalSlushie : Card_Item
{
    public override string CardId => "77028";
    public override string CardNumber => "BS1-049";
    public override string CardName => "Tropical Slushie";
    public override string CardText => "《{Y}{Y}》 Deals 1 damage for each 1 {Y} LV.2 or higher Cookie in your break area to 1 of your opponent's Cookies.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImageName => "BS1_049.png";

    public TropicalSlushie()
    {
        Debug.Log("TropicalSlushie::TropicalSlushie");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("TropicalSlushie::ActivateAbility");
        throw new System.NotImplementedException();
    }
}