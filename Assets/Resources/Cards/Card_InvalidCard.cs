using UnityEngine;

public class Card_InvalidCard : Card_Base
{
    protected override CardType GetCardType()
    {
        return CardType.Invalid;
    }
}