using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_Item_", menuName = "Cards/Item Card", order = 2)]
public class Card_Item : Card_Base
{
    protected override CardType GetCardType()
    {
        return CardType.Item;
    }
}
