using System.Collections;
using UnityEngine;

public class UIController_Hand : UIController_Base
{
    [SerializeField] private Transform handTransform;
    [SerializeField] private float offset = 1.5f;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);
        RepositionAllCards();
    }

    public override void RemoveCard(int cardMatchId)
    {
        base.RemoveCard(cardMatchId);
        RepositionAllCards();
    }

    private void RepositionAllCards()
    {
        float totalWidth = (cards.Count - 1) * offset;
        float centerOffset = totalWidth / 2f;

        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 targetPosition = handTransform.position + new Vector3((offset * i) - centerOffset, 0, 0);
            StartCoroutine(LerpCardToPosition(cards[i], targetPosition));
        }
    }
}