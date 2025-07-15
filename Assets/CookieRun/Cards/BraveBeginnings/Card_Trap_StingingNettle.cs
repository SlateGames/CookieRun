using UnityEngine;

public class Card_Trap_StingingNettle : Card_Trap
{
    public override string CardId => "77096";
    public override string CardNumber => "BS1-076";
    public override string CardName => "Stinging Nettle";
    public override string CardText => "《{G}》 Select up to 1 of your opponent's Cookies. That Cookie receives 1 damage. Then, place 1 card from your support area into the trash.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImagePath => "BS1_076.png.webp";
}