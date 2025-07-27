using TMPro;
using UnityEngine;

public class UIController_Deck : UIController_Base
{
    [SerializeField] private Transform deckTransform;
    [SerializeField] private TMP_Text deckCountText;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);

        //TODO: Find a better way. I would rather just not send this data to the client
        card.GetComponent<CardVisualController>().ClearCard();
        UpdateDeckCount();

        if (deckTransform != null)
        {
            StartCoroutine(LerpCardToPosition(card, deckTransform.position));
        }
    }

    public override void RemoveCard(int cardMatchId)
    {
        base.RemoveCard(cardMatchId);
        UpdateDeckCount();
    }

    private void UpdateDeckCount()
    {
        if (deckCountText != null)
        {
            deckCountText.text = cards.Count.ToString();
        }
    }
}