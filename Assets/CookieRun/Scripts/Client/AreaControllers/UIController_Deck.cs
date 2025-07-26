using TMPro;
using UnityEngine;

public class UIController_Deck : UIController_Base
{
    [SerializeField] private Transform deckTransform;
    [SerializeField] private TMP_Text deckCountText;

    public override void AddCard(GameObject card)
    {
        base.AddCard(card);
        UpdateDeckCount();
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