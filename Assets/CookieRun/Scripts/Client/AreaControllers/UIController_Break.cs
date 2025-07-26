using System.Collections;
using TMPro;
using UnityEngine;

public class UIController_Break : UIController_Base
{
    [SerializeField] private Transform stackTransform;
    [SerializeField] private Vector3 offset = new Vector3(0, -0.5f, 0);
    [SerializeField] private TMP_Text breakScoreText;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);

        if (card != null && stackTransform != null)
        {
            int cardIndex = cards.IndexOf(card);
            Vector3 targetPosition = stackTransform.position + (offset * cardIndex);

            StartCoroutine(LerpCardToPosition(card, targetPosition));
        }
    }

    public override void RemoveCard(int cardMatchId)
    {
        base.RemoveCard(cardMatchId);

        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 targetPosition = stackTransform.position + (offset * i);
            StartCoroutine(LerpCardToPosition(cards[i], targetPosition));
        }
    }

    public void UpdateBreakScore(int score)
    {
        if (breakScoreText != null)
        {
            breakScoreText.SetText(score.ToString());
        }
    }
}