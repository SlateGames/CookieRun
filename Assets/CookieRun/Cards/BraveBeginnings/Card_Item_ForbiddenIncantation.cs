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
    public override string ImagePath => "BS2_077.png";
}