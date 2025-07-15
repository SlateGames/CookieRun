using UnityEngine;

public class Card_Trap_SaltCrystalTrident : Card_Trap
{
    public override string CardId => "77224";
    public override string CardNumber => "BS2-049";
    public override string CardName => "Salt Crystal Trident";
    public override string CardText => "《{B}》 During this battle, if 1 of your {B} Cookies faints, you can draw up to 3 cards from your deck and discard 1 card from your hand.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Blue;
    public override string ImagePath => "BS2_049.png.webp";
}