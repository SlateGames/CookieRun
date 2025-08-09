using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_Trap_", menuName = "Cards/Trap Card", order = 4)]
public class Card_Trap : Card_Base
{
    protected override CardType GetCardType()
    {
        return CardType.Trap;
    }
}
