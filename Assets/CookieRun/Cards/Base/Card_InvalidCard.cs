using UnityEngine;

public class Card_InvalidCard : Card_Base
{
    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("Card_InvalidCard::ActivateAbility");
        throw new System.NotImplementedException();
    }
}