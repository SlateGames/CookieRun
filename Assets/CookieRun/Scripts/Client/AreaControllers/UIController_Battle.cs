using System.Collections;
using UnityEngine;

public class UIController_Battle : UIController_Base
{
    [SerializeField] private Transform position1Transform;
    [SerializeField] private Transform position2Transform;

    private GameObject position1Card = null;
    private GameObject position2Card = null;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);

        if (card != null)
        {
            Transform targetTransform = null;

            if (position1Card == null)
            {
                targetTransform = position1Transform;
                position1Card = card;
            }
            else if (position2Card == null)
            {
                targetTransform = position2Transform;
                position2Card = card;
            }

            if (targetTransform != null)
            {
                StartCoroutine(LerpCardToPosition(card, targetTransform.position));
            }
        }
    }

    public override void RemoveCard(int cardMatchId)
    {
        GameObject cardToRemove = null;

        if (position1Card != null)
        {
            var cardController = position1Card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == cardMatchId)
            {
                cardToRemove = position1Card;
                position1Card = null;
            }
        }
        if (cardToRemove == null && position2Card != null)
        {
            var cardController = position2Card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == cardMatchId)
            {
                cardToRemove = position2Card;
                position2Card = null;
            }
        }

        if (cardToRemove != null)
        {
            cards.Remove(cardToRemove);
        }
    }
}