using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class UIController_Support : UIController_Base
{
    [SerializeField] private Transform supportTransform;
    [SerializeField] private float offset = 1.0f;

    // Event to fire when a support card is clicked
    public event Action<int> SupportCardClicked;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);

        CookieRunButton cookieRunButton = card.GetComponent<CookieRunButton>();
        CardController cardController = card.GetComponent<CardController>();
        if (cookieRunButton != null && cardController != null)
        {
            cookieRunButton.OnLeftClick.AddListener(() => OnCardClicked(cardController));
        }

        if (card != null && supportTransform != null)
        {
            int cardIndex = cards.IndexOf(card);
            Vector3 targetPosition = supportTransform.position + new Vector3(offset * cardIndex, 0, 0);

            StartCoroutine(LerpCardToPosition(card, targetPosition));
        }
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
    }

    private void OnCardClicked(CardController cardController)
    {
        int matchId = cardController.GetCardMatchId();
        SupportCardClicked?.Invoke(matchId);
    }

    public void TapCard(int cardMatchId)
    {
        GameObject card = null;

        for (int i = 0; i < cards.Count; i++)
        {
            var cardController = cards[i].GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == cardMatchId)
            {
                card = cards[i];
                break;
            }
        }

        if (card != null)
        {
            card.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    public void UntapCard(int cardMatchId)
    {
        GameObject card = null;

        for (int i = 0; i < cards.Count; i++)
        {
            var cardController = cards[i].GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == cardMatchId)
            {
                card = cards[i];
                break;
            }
        }

        if (card != null)
        {
            card.transform.rotation = Quaternion.identity;
        }
    }
}