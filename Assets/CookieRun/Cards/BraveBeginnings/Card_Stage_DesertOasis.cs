using UnityEngine;

public class Card_Stage_DesertOasis : Card_Stage
{
    public override string CardId => "76968";
    public override string CardNumber => "BS1-026";
    public override string CardName => "Desert Oasis";
    public override string CardText => "《{R}{R}》 Place in your stage area.\n【Activate】 《Rest this card.》 《Place 1 of your Cookies' HP cards in the trash.》 Select up to 1 of your Cookies. During this turn, that Cookie gains +1 attack damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Stage;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImagePath => "BS1_026.png.webp";
}