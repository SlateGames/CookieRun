using UnityEngine;

public class CardController : MonoBehaviour
{
    private string cardId;
    private int cardMatchId;
    [SerializeField] private CardVisualController visualController;

    public int GetCardMatchId()
    {
        return cardMatchId;
    }

    public void Initialize(Card_Base card)
    {
        if (card != null)
        {
            cardId = card.CardId;

            if (visualController != null && !string.IsNullOrEmpty(card.ImageName))
            {
                visualController.LoadImageFromName(card.ImageName);
            }
        }
    }

    public void UpdateCardMatchId(int newCardMatchId)
    {
        cardMatchId = newCardMatchId;
    }
}