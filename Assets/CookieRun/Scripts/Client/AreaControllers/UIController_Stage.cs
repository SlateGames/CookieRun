using System.Collections;
using UnityEngine;

public class UIController_Stage : UIController_Base
{
    [SerializeField] private Transform stageTransform;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);

        if (card != null && stageTransform != null)
        {
            StartCoroutine(LerpCardToPosition(card, stageTransform.position));
        }
    }
}