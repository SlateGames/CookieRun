using UnityEngine;

public class CardController : MonoBehaviour
{
    private string cardId;
    private int cardMatchId;
    private Card_Base card;

    [SerializeField] private CardVisualController visualController;

    public void Initialize(Card_Base card)
    {
        if (card == null)
        {
            Debug.LogError("Cannot initialize off a null card");
            return;

        }

        this.card = card;
        cardId = card.CardId;

        UpdateCardImage();
    }

    public void UpdateCardImage()
    {
        if (card != null)
        {
            if (visualController != null && card.CardTexture != null)
            {
                visualController.LoadImage(card.CardTexture);
            }
        }
    }

    public int GetCardMatchId()
    {
        return cardMatchId;
    }

    public void UpdateCardMatchId(int newCardMatchId)
    {
        cardMatchId = newCardMatchId;
    }
}