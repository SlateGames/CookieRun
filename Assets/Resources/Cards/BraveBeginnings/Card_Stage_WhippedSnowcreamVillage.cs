using UnityEngine;

public class Card_Stage_WhippedSnowcreamVillage : Card_Stage
{
    public override string CardId => "77228";
    public override string CardNumber => "BS2-051";
    public override string CardName => "Whipped Snowcream Village";
    public override string CardText => "《{B}{B}》 Place in your stage area.\n【Activate】 《Card Rests.》 《Discard 1 card.》 Select up to 1 of your Cookies. During this turn, that Cookie deals +1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Stage;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImageName => "BS2_051.png";
}