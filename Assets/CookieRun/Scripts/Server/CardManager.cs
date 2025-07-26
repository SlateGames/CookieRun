using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

public struct DeckDataPayload : INetworkSerializable
{
    public ulong PlayerId;
    public string DeckId;
    public Deck Deck;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref PlayerId);
        serializer.SerializeValue(ref DeckId);
        serializer.SerializeValue(ref Deck);
    }
}

public class CardManager
{
    private static SynchronizationContext _mainThreadContext;
    private string _persistentDataPath;

    public int GetNextMatchId() => Interlocked.Increment(ref _nextMatchId);
    private int _nextMatchId;
    private ConcurrentBag<DeckDataPayload> _deckPayloads = new ConcurrentBag<DeckDataPayload>();
    private Dictionary<int, Card_Base> _cardsByMatchId;
    private Dictionary<string, Card_Base> _cardsByCardID;

    private Deck _player1Deck;
    private Deck _player2Deck;

    public CardManager()
    {
        Debug.Log("CardManager::CardManager");

        _mainThreadContext = SynchronizationContext.Current;
        _persistentDataPath = Application.persistentDataPath;

        _cardsByMatchId = new Dictionary<int, Card_Base>();
        _cardsByCardID = new Dictionary<string, Card_Base>();

        InitializeCardCache();
    }

    public void InitializeCardCache()
    {
        List<Card_Base> allCards = LoadAllCardClasses();
        foreach (Card_Base card in allCards)
        {
            _cardsByCardID[card.CardId] = card;
        }
    }

    public List<Card_Base> LoadAllCardClasses()
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

        return cards;
    }

    public void RegisterDeckForPlayer(ulong playerId, Deck deck)
    {
        Debug.Log("CardManager::RegisterDeckForPlayer");
            
        DeckDataPayload deckDataPayload = new DeckDataPayload();
        deckDataPayload.PlayerId = playerId;
        deckDataPayload.DeckId = deck.DeckID;
        deckDataPayload.Deck = deck;

        //TODO: I should not do this here, but instead have some kind of event system that handles this
        if (playerId == RulesEngine.Instance.GetGameStateManager().Player1Id)
        {
            Debug.Log($"GameState: Registering deck {deck.Name} for player {playerId}.");
            _player1Deck = deck;
        }
        else if (playerId == RulesEngine.Instance.GetGameStateManager().Player2Id)
        {
            Debug.Log($"GameState: Registering deck {deck.Name} for player {playerId}.");
            _player2Deck = deck;
        }
        else
        {
            Debug.Log($"GameState: Could not register deck {deck.Name} for a player, as the ID {playerId} is not associated with either player.");
            return;
        }

        RulesEngine.Instance.BroadcastDeckRegisteredForPlayerEvent(deckDataPayload);

        _deckPayloads.Add(deckDataPayload);
        if (_deckPayloads.Count >= 2)
        {
            LoadDecks();
        }
    }

    private async void LoadDecks()
    {
        foreach (var deckPayload in _deckPayloads)
        {
            string deckId = deckPayload.DeckId;
            ulong playerId = deckPayload.PlayerId;
            Deck deck = deckPayload.Deck;

            Debug.Log($"Deck ID: {deck.DeckID}, Deck Name: {deck.Name}, Cards in Deck: {deck.Cards.Count}");
            //TODO: I should clean this up, make it better
            ProcessDeck(deck, playerId);
        }
    }

    private void ProcessDeck(Deck deck, ulong playerId)
    {
        Debug.Log("CardManager::LoadDecks");

        List<string> cardIds = new List<string>();

        foreach (var deckCard in deck.Cards)
        {
            cardIds.Add(deckCard.CardID);
        }

        Debug.Log($"Card_Base IDs Count: {cardIds.Count}");

        List<Card_Base> deckCards = new List<Card_Base>();
            
        foreach (var deckCard in deck.Cards)
        {
            string cardId = deckCard.CardID;
            int quantity = deckCard.Quantity;

            for (int j = 0; j < quantity; j++)
            {
                if (!_cardsByCardID.TryGetValue(cardId, out Card_Base card))
                {
                    Debug.LogError($"Card_Base {cardId} not found!");
                    continue;
                }

                deckCards.Add(card);
            }
        }

        RegisterDeckCards(deckCards, playerId);
    }

    private void RegisterDeckCards(List<Card_Base> cards, ulong playerId)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card_Base card = cards[i];

            int currentMatchId = GetNextMatchId();
            card.MatchID = currentMatchId;
            cards[i] = card;

            Debug.Log($"Registering {card.CardName} with Match ID {currentMatchId}");
            _cardsByMatchId.TryAdd(currentMatchId, card);
            
            RulesEngine.Instance.GetGameZoneManager().MoveCardFromZoneToZone(playerId, currentMatchId, GameZoneType.Invalid, GameZoneType.Deck);
        }            
    }

    public Card_Base GetCardByMatchId(int cardMatchId)
    {
        Debug.Log("CardManager::GetCardByMatchId");

        if (_cardsByMatchId.ContainsKey(cardMatchId) == false)
        {
            Debug.Log($"Server has no Card_Base with Match ID: {cardMatchId}.");
            return null;
        }

        return _cardsByMatchId[cardMatchId];
    }
}