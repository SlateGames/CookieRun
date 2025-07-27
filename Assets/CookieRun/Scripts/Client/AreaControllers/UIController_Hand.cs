using System;
using System.Collections;
using UnityEngine;

public class UIController_Hand : UIController_Base
{
    [SerializeField] private Transform handTransform;
    [SerializeField] private float offset = 1.5f;

    public event Action<int> HandCardClicked;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);

        CookieRunButton cookieRunButton = card.GetComponent<CookieRunButton>();
        CardController cardController = card.GetComponent<CardController>();
        if (cookieRunButton != null && cardController != null)
        {
            cookieRunButton.OnLeftClick.AddListener(() => OnCardClicked(cardController));
        }

        RepositionAllCards();
    }

    public override void RemoveCard(int cardMatchId)
    {
        GameObject cardToRemove = null;
        foreach (GameObject card in cards)
        {
            CardController cardController = card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == cardMatchId)
            {
                cardToRemove = card;
                break;
            }
        }

        if (cardToRemove != null)
        {
            CookieRunButton cookieRunButton = cardToRemove.GetComponent<CookieRunButton>();
            if (cookieRunButton != null)
            {
                cookieRunButton.OnLeftClick.RemoveAllListeners();
            }
        }

        base.RemoveCard(cardMatchId);
        RepositionAllCards();
    }

    private void OnCardClicked(CardController cardController)
    {
        int matchId = cardController.GetCardMatchId();
        HandCardClicked?.Invoke(matchId);
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