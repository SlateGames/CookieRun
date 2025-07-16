using UnityEngine;

public class Card_Item_JellyPomPoms : Card_Item
{
    public override string CardId => "77026";
    public override string CardNumber => "BS1-048";
    public override string CardName => "Jelly Pom-Poms";
    public override string CardText => "《{Y}{Y}{Y}》 Select up to 1 of your Cookies. During this turn, that Cookie gains +1 attack damage for every 2 {Y} LV.1 Cookies in your break area.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Item;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS1_048.png";
}