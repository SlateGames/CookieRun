using UnityEngine;

public class Card_Trap_TastyFirstAidKit : Card_Trap
{
    public override string CardId => "77098";
    public override string CardNumber => "BS1-077";
    public override string CardName => "Tasty First Aid Kit";
    public override string CardText => "《{G}{G}{G}》 Select up to 1 of your opponent's Cookies. During this turn, that Cookie deals -3 attack damage. Then, set up to 1 of card from your support area as active.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Green;
    public override string ImagePath => "BS1_077.png.webp";
}