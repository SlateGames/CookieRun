using UnityEngine;

public class Card_Trap_ErraticYakgwaRobot : Card_Trap
{
    public override string CardId => "77132";
    public override string CardNumber => "BS2-014";
    public override string CardName => "Erratic Yakgwa Robot";
    public override string CardText => "《{Y}》 Select up to 1 of your opponent's Cookies. During this turn, that Cookie deals -1 attack damage. Then, you can return 1 LV.1 Cookie from your break area to your hand. If you did, place 1 Cookie from your hand into your break area.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Yellow;
    public override string ImagePath => "BS2_014.png.webp";
}