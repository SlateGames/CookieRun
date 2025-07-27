using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController_Trash : UIController_Base
{
    [SerializeField] private Transform trashTransform;
    [SerializeField] private CookieRunButton trashButton;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);

        if (card != null && trashTransform != null)
        {
            StartCoroutine(LerpCardToPosition(card, trashTransform.position));
        }
    }

    public void ExpandTrash()
    {
        //TODO: Make a new overlay
    }
}