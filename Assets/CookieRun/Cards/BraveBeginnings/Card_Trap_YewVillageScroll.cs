using UnityEngine;

public class Card_Trap_YewVillageScroll : Card_Trap
{
    public override string CardId => "77304";
    public override string CardNumber => "BS2-079";
    public override string CardName => "Yew Village Scroll";
    public override string CardText => "《{P}》 Select up to 1 of your opponent's Cookies. During this turn, that Cookie deals -1 attack damage. Then, select up to 5 cards from your trash that do not have FLIP. Return those cards to your deck and shuffle it.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Purple;
    public override string ImagePath => "BS2_079.png";
}