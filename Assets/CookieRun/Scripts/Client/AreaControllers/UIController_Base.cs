using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_Base : MonoBehaviour
{
    [SerializeField] protected bool IsOpponent;
    [SerializeField] protected GameZoneType ZoneType;

    protected List<GameObject> cards = new List<GameObject>();

    public virtual void AddCard(GameObject card)
    {
        if (card != null && !cards.Contains(card))
        {
            cards.Add(card);
        }
    }

    public virtual void RemoveCard(int cardMatchId)
    {
        GameObject cardToRemove = null;

        for (int i = 0; i < cards.Count; i++)
        {
            var cardController = cards[i].GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == cardMatchId)
            {
                cardToRemove = cards[i];
                break;
            }
        }

        if (cardToRemove != null)
        {
            cards.Remove(cardToRemove);
        }
    }

    protected IEnumerator LerpCardToPosition(GameObject card, Vector3 targetPosition)
    {
        float duration = 0.5f;
        float elapsed = 0f;
        Vector3 startPosition = card.transform.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            card.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        card.transform.position = targetPosition;
    }
}