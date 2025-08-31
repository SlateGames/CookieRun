using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZoneManager : MonoBehaviour
{
    //TODO: Skip the dictionary/ies?

    private Dictionary<ulong, Dictionary<GameZoneType, GameZone_Base>> _gameZonesByTypeByPlayer;

    public GameZoneManager()
    {
        _gameZonesByTypeByPlayer = new Dictionary<ulong, Dictionary<GameZoneType, GameZone_Base>>();
    }

    public void RegisterPlayer(ulong playerId)
    {
        Dictionary<GameZoneType, GameZone_Base> GameZone_ForPlayer = new Dictionary<GameZoneType, GameZone_Base>();

        Debug.Log("GameStateManager: Adding Battle Zone.");
        GameZone_ForPlayer.Add(GameZoneType.Battle, new GameZone_Battle());

        Debug.Log("GameStateManager: Adding Break Zone.");
        GameZone_ForPlayer.Add(GameZoneType.Break, new GameZone_Break());

        Debug.Log("GameStateManager: Adding Deck Zone.");
        GameZone_ForPlayer.Add(GameZoneType.Deck, new GameZone_Deck());

        Debug.Log("GameStateManager: Adding Trash Zone.");
        GameZone_ForPlayer.Add(GameZoneType.Trash, new GameZone_Trash());

        Debug.Log("GameStateManager: Adding Hand Zone.");
        GameZone_ForPlayer.Add(GameZoneType.Hand, new GameZone_Hand());

        Debug.Log("GameStateManager: Adding Stage Zone.");
        GameZone_ForPlayer.Add(GameZoneType.Stage, new GameZone_Stage());

        Debug.Log("GameStateManager: Adding Support Zone.");
        GameZone_ForPlayer.Add(GameZoneType.Support, new GameZone_Support());

        Debug.Log("GameStateManager: Adding Health Pool Zone.");
        GameZone_ForPlayer.Add(GameZoneType.HealthPool, new GameZone_HealthPool());

        _gameZonesByTypeByPlayer.Add(playerId, GameZone_ForPlayer);

        foreach (var GameZone_ in _gameZonesByTypeByPlayer[playerId])
        {
            GameZone_.Value.OwningPlayerId = playerId;
        }
    }

    //TODO: Can this, DrawCards, and MulliganCardsForPlayer be moved to CardManager?
    public void ShuffleDeckForPlayer(ulong playerId)
    {
        if (_gameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return;
        }
        if (_gameZonesByTypeByPlayer[playerId].ContainsKey(GameZoneType.Deck) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a Deck zone for player {playerId}.");
            return;
        }

        Debug.Log($"Player {playerId}'s deck is being shuffled.");
        ((GameZone_Deck)_gameZonesByTypeByPlayer[playerId][GameZoneType.Deck]).Shuffle();
    }

    public void DrawCards(ulong playerId, int amountToDraw, int sourceCardMatchId)
    {
        Debug.Log("GameStateManager::DrawCards");

        if (_gameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return;
        }
        if (_gameZonesByTypeByPlayer[playerId].ContainsKey(GameZoneType.Deck) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a deck zone for player {playerId}.");
            return;
        }

        GameZone_Deck deck = (GameZone_Deck)_gameZonesByTypeByPlayer[playerId][GameZoneType.Deck];
        List<int> drawnCards = new List<int>();
        for (int i = 0; i < amountToDraw; i++)
        {
            int topCardId = deck.GetTopCardMatchID();
            Debug.Log($"GameStateManager: Top Card_Base Match ID: {topCardId}.");

            drawnCards.Add(topCardId);
            if (topCardId == CookieRunConstants.INVALID_CARD_MATCH_ID)
            {
                //TODO: Shuffle Trash into library
            }

            MoveCardFromZoneToZone(playerId, topCardId, GameZoneType.Deck, GameZoneType.Hand);
        }
    }
    
    public List<int> GetTopCardMatchIds(ulong playerId, int amountToDraw, int sourceCardMatchId)
    {
        Debug.Log("GameStateManager::GetTopCardMatchIds");

        List<int> drawnCards = new List<int>();

        if (_gameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return drawnCards;
        }
        if (_gameZonesByTypeByPlayer[playerId].ContainsKey(GameZoneType.Deck) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a deck zone for player {playerId}.");
            return drawnCards;
        }

        GameZone_Deck deck = (GameZone_Deck)_gameZonesByTypeByPlayer[playerId][GameZoneType.Deck];
        for (int i = 0; i < amountToDraw; i++)
        {
            int topCardId = deck.GetTopCardMatchID();
            Debug.Log($"GameStateManager: Top Card_Base Match ID: {topCardId}.");

            drawnCards.Add(topCardId);
            if (topCardId == CookieRunConstants.INVALID_CARD_MATCH_ID)
            {
                //TODO: Shuffle Trash into library
            }
        }

        return drawnCards;
    }

    public void MulliganCardsForPlayer(ulong playerId)
    {
        foreach (var cardId in GetCardsInZone(playerId, GameZoneType.Hand))
        {
            Debug.Log($"Putting Card_Base Match ID {cardId} back into deck.");
            MoveCardFromZoneToZone(playerId, cardId, GameZoneType.Hand, GameZoneType.Deck);
        }

        ShuffleDeckForPlayer(playerId);
        DrawCards(playerId, 6, CookieRunConstants.GAME_ACTION);
    }

    public GameZoneType GetZoneCardIsPresentIn(int cardMatchId)
    {
        Debug.Log("GameStateManager::GetZoneCardIsPresentIn");

        foreach (KeyValuePair<ulong, Dictionary<GameZoneType, GameZone_Base>> kvp in _gameZonesByTypeByPlayer)
        {
            Debug.Log($"Checking zones belonging to player {kvp.Key}.");

            foreach (KeyValuePair<GameZoneType, GameZone_Base> zone in kvp.Value)
            {
                Debug.Log($"Checking zone {zone.Key.ToString()}.");

                if (zone.Value.IsCardPresent(cardMatchId))
                {
                    Debug.Log($"Zone {zone.Key.ToString()} controlled by Player {kvp.Key} contains the Card_Base Match ID {cardMatchId}.");
                    return zone.Key;
                }
            }
        }

        return GameZoneType.Invalid;
    }

    //TODO: Should I add the owning player ID to Card_Base or the dictionary?
    public ulong GetControllerOfCardByMatchId(int cardMatchId)
    {
        Debug.Log("GameStateManager::GetControllerOfCardByMatchId");

        foreach (KeyValuePair<ulong, Dictionary<GameZoneType, GameZone_Base>> kvp in _gameZonesByTypeByPlayer)
        {
            Debug.Log($"Checking zones belonging to player {kvp.Key}.");

            foreach (KeyValuePair<GameZoneType, GameZone_Base> zone in kvp.Value)
            {
                Debug.Log($"Checking zone {zone.Key.ToString()}.");

                if (zone.Value.IsCardPresent(cardMatchId))
                {
                    Debug.Log($"Zone {zone.Key.ToString()} controlled by Player {kvp.Key} contains the Card_Base Match ID {cardMatchId}.");
                    return kvp.Key;
                }
            }
        }

        Debug.Log($"No Zone for either player contains {cardMatchId}.");
        return CookieRunConstants.INVALID_PLAYER_ID;
    }

    public IReadOnlyList<int> GetAllCardMatchIdsForPlayer(ulong playerId)
    {
        Debug.Log("GameStateManager::GetAllCardMatchIdsForPlayer");

        if (_gameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return new List<int>();
        }

        List<int> allCookieIds = new List<int>();

        foreach (KeyValuePair<GameZoneType, GameZone_Base> zone in _gameZonesByTypeByPlayer[playerId])
        {
            allCookieIds.AddRange(zone.Value.GetCards());
        }

        return allCookieIds;
    }

    public IReadOnlyList<int> GetCardsInZone(ulong playerId, GameZoneType zone)
    {
        Debug.Log("GameStateManager::GetCardsInZone");

        if (_gameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return new List<int>();
        }
        if (_gameZonesByTypeByPlayer[playerId].ContainsKey(zone) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a {zone.ToString()} zone for player {playerId}.");
            return new List<int>();
        }

        return _gameZonesByTypeByPlayer[playerId][zone].GetCards();
    }

    public List<int> GetCardsInPlayForPlayer(ulong playerId)
    {
        Debug.Log("GameStateManager::GetCardsInPlayForPlayer");

        List<int> cards = new List<int>();

        cards.AddRange(GetCardsInZone(playerId, GameZoneType.Support));
        cards.AddRange(GetCardsInZone(playerId, GameZoneType.Battle));
        cards.AddRange(GetCardsInZone(playerId, GameZoneType.Stage));

        return cards;
    }

    public List<int> GetCookiesPlayerControls(ulong playerId)
    {
        Debug.Log("GameStateManager::GetCookiesPlayerControls");

        if (_gameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return new List<int>();
        }
        if (_gameZonesByTypeByPlayer[playerId].ContainsKey(GameZoneType.Battle) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a Battle zone for player {playerId}.");
            return new List<int>();
        }

        return new List<int>(_gameZonesByTypeByPlayer[playerId][GameZoneType.Battle].GetCards());
    }

    //TODO: Make this private. Remove the broadcast. Make a series of functions for each type of movement, each with their own broadcast. `MoveCardFromDeckToHand`, for example, will fire an event `CardMovedFromDeckToHand`.
    //I can do this because of the limited amount of movement types
    public void MoveCardFromZoneToZone(ulong playerId, int cardMatchId, GameZoneType sourceZone, GameZoneType destinationZone)
    {
        Debug.Log("GameStateManager::MoveCardFromZoneToZone");

        if (cardMatchId == CookieRunConstants.INVALID_CARD_MATCH_ID)
        {
            Debug.Log("cardMatchId is invalid");
            return;
        }
        if (_gameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return;
        }
        if (((sourceZone == GameZoneType.Invalid && RulesEngine.Instance.GetGameStateManager().GetCurrentPhase() == GamePhase.Setup) == false) && _gameZonesByTypeByPlayer[playerId].ContainsKey(sourceZone) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a {sourceZone.ToString()} zone for player {playerId}.");
            return;
        }
        if (_gameZonesByTypeByPlayer[playerId].ContainsKey(destinationZone) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a {destinationZone.ToString()} zone for player {playerId}.");
            return;
        }

        if(sourceZone != GameZoneType.Invalid)
        {
            _gameZonesByTypeByPlayer[playerId][sourceZone].RemoveCard(cardMatchId);
        }
        _gameZonesByTypeByPlayer[playerId][destinationZone].AddCard(cardMatchId);

        Card_Base card = RulesEngine.Instance.GetCardManager().GetCardByMatchId(cardMatchId);
        RulesEngine.Instance.BroadcastCardMovedFromZoneToZone(playerId, card.CardId, cardMatchId, sourceZone, destinationZone);
    }

    public bool CanAddCardToZone(ulong playerId, int cardMatchId, GameZoneType zone)
    {
        Debug.Log("GameStateManager::CanAddCardToZone");

        if (_gameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return false;
        }
        if (_gameZonesByTypeByPlayer[playerId].ContainsKey(zone) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a {zone.ToString()} zone for player {playerId}.");
            return false;
        }
        if (_gameZonesByTypeByPlayer[playerId][zone].CanAddCardToZone(cardMatchId) == false)
        {
            Debug.Log($"GameStateManager: Unable to add {cardMatchId} to {zone.ToString()} zone for player {playerId}.");
            return false;
        }

        return true;
    }
}
