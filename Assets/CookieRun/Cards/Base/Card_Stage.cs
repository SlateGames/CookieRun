using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_Stage_", menuName = "Cards/Stage Card", order = 3)]
public class Card_Stage : Card_Base
{
    protected override CardType GetCardType()
    {
        return CardType.Stage;
    }
}
