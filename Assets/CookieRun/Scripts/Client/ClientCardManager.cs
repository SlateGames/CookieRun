using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ClientCardManager : MonoBehaviour
{
    public static ClientCardManager Instance { get; private set; }

    [SerializeField] private GameObject cardPrefab;

    private Dictionary<string, Card_Base> cardCache = new Dictionary<string, Card_Base>();

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CacheAllCards();
    }

    private void CacheAllCards()
    {
        var cardTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Card_Base)) && !t.IsAbstract);

        List<Card_Base> cards = new List<Card_Base>();

        foreach (var type in cardTypes)
        {
            Card_Base cardInstance = (Card_Base)ScriptableObject.CreateInstance(type);
            cards.Add(cardInstance);
        }
        
        foreach (Card_Base card in cards)
        {
            if (!string.IsNullOrEmpty(card.CardId))
            {
                if (!cardCache.ContainsKey(card.CardId))
                {
                    cardCache[card.CardId] = card;
                }
                else
                {
                    Debug.LogWarning($"Duplicate card ID found: {card.CardId}");
                }
            }
            else
            {
                Debug.LogError($"Card {card.name} has no Card ID assigned!");
            }
        }

        Debug.Log($"Cached {cardCache.Count} cards");
    }

    public GameObject GetCardInstance(string cardId)
    {
        //TODO: Track cards after they get instantiated
        if (cardCache.TryGetValue(cardId, out Card_Base cardData))
        {
            GameObject cardInstance = Instantiate(cardPrefab);
            CardController cardController = cardInstance.GetComponent<CardController>();
            
            if (cardController != null)
            {
                cardController.Initialize(cardData);
                return cardInstance;
            }
            else
            {
                Debug.LogError("Card prefab is missing CardController component!");
                Destroy(cardInstance);
                return null;
            }
        }
        else
        {
            Debug.LogError($"Card with ID '{cardId}' not found in cache!");
            return null;
        }
    }
}