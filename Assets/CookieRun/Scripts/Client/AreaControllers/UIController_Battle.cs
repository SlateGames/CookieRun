using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIController_Battle : UIController_Base
{
    [SerializeField] private Transform position1Transform;
    [SerializeField] private Transform position2Transform;

    private GameObject position1Card = null;
    private GameObject position2Card = null;

    private List<GameObject> position1HealthPool = new List<GameObject>();
    private List<GameObject> position2HealthPool = new List<GameObject>();

    public event Action<int> OnCardRemovedFromHealthPool;

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

    public void AddToHealthPool(int parentCardMatchId, GameObject healthCard)
    {
        if (healthCard == null)
        {
            return;
        }

        var visualController = healthCard.GetComponent<CardVisualController>();
        if (visualController != null)
        {
            visualController.ClearCard();
        }

        List<GameObject> targetHealthPool = null;

        if (position1Card != null)
        {
            var cardController = position1Card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == parentCardMatchId)
            {
                targetHealthPool = position1HealthPool;
            }
        }
        if (position2Card != null)
        {
            var cardController = position2Card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == parentCardMatchId)
            {
                targetHealthPool = position2HealthPool;
            }
        }

        if (targetHealthPool != null)
        {
            targetHealthPool.Add(healthCard);
            PositionHealthCard(parentCardMatchId, healthCard, targetHealthPool);
        }
    }

    public void RemoveFromHealthPool(int parentCardMatchId)
    {
        List<GameObject> targetHealthPool = null;

        if (position1Card != null)
        {
            var cardController = position1Card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == parentCardMatchId)
            {
                targetHealthPool = position1HealthPool;
            }
        }
        if (position2Card != null)
        {
            var cardController = position2Card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == parentCardMatchId)
            {
                targetHealthPool = position2HealthPool;
            }
        }

        if (targetHealthPool == null || targetHealthPool.Count == 0)
        {
            return;
        }

        GameObject cardToRemove = targetHealthPool[targetHealthPool.Count - 1];
        targetHealthPool.RemoveAt(targetHealthPool.Count - 1);

        StartCoroutine(RemoveHealthCardAnimation(cardToRemove));
    }

    private void PositionHealthCard(int parentCardMatchId, GameObject healthCard, List<GameObject> healthPool)
    {
        Transform parentTransform = null;

        if (position1Card != null)
        {
            var cardController = position1Card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == parentCardMatchId)
            {
                parentTransform = position1Card.transform;
            }
        }
        if (position2Card != null)
        {
            var cardController = position2Card.GetComponent<CardController>();
            if (cardController != null && cardController.GetCardMatchId() == parentCardMatchId)
            {
                parentTransform = position2Card.transform;
            }
        }

        if (parentTransform != null)
        {
            int healthCardCount = healthPool.Count - 1;
            Vector3 offset = new Vector3(healthCardCount * 0.1f, -healthCardCount * 0.05f, -healthCardCount * 0.01f);
            Vector3 targetPosition = parentTransform.position + offset;

            StartCoroutine(LerpCardToPosition(healthCard, targetPosition));
        }
    }

    private IEnumerator RemoveHealthCardAnimation(GameObject card)
    {
        if (card == null)
        {
            yield break;
        }

        var cardController = card.GetComponent<CardController>();
        int cardMatchId = 0;

        if (cardController != null)
        {
            cardMatchId = cardController.GetCardMatchId();
        }

        float rotationTime = 0.2f;
        float rotationSpeed = 720f / rotationTime;
        float elapsedTime = 0f;

        while (elapsedTime < rotationTime)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            card.transform.Rotate(0, rotationThisFrame, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (cardController != null)
        {
            cardController.UpdateCardImage();
        }

        rotationTime = 0.1f;
        rotationSpeed = 360f / rotationTime;
        elapsedTime = 0f;

        while (elapsedTime < rotationTime)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            card.transform.Rotate(0, rotationThisFrame, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        OnCardRemovedFromHealthPool?.Invoke(cardMatchId);
    }
}