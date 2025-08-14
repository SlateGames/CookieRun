using UnityEngine;

public class Card_Trap_PastaSpringShoes : Card_Trap
{
    public override string CardId => "76964";
    public override string CardNumber => "BS1-024";
    public override string CardName => "Pasta Spring Shoes";
    public override string CardText => "《{R}{R}》 If 1 of your Cookies has 1 HP, select up to 1 of your opponent's Cookies. During this turn, that Cookie deals -4 attack damage.";
    public override CardRarity CardRarity => CardRarity.Uncommon;
    public override CardType CardType => CardType.Trap;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_024.png";

    public Card_Trap_PastaSpringShoes()
    {
        Debug.Log("Card_Trap_PastaSpringShoes::Card_Trap_PastaSpringShoes");
        CardAbility cardAbility01 = new CardAbility();
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_Trap_PastaSpringShoes::ActivateAbility");
        throw new System.NotImplementedException();
    }
}