using UnityEngine;

public class Card_Stage_BlueDragonsEye : Card_Stage
{
    public override string CardId => "77308";
    public override string CardNumber => "BS2-081";
    public override string CardName => "Blue Dragon's Eye";
    public override string CardText => "《{P}》 Place in your stage area.\n【Activate】 《{P}》 《Place this card in the trash.》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Stage;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_081.png.webp";
}