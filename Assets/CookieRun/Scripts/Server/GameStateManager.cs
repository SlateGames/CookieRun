using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum GamePhase
{
    Setup,
    Active,
    Draw,
    Support,
    Main,
    Battle,
    End
}

public enum SetupPhase
{
    GamePreparation,
    Mulligans,
    PreGameCookiePlacement
}

public enum BattlePhase
{
    Attack,
    Trap,
    Resolution
}


//TODO: Should I have a GameZone_Manager?
public class GameStateManager
{
    private bool HasPlayer1BeenRegistered = false;
    private bool HasPlayer2BeenRegistered = false;

    public ulong Player1Id;
    public ulong Player2Id;

    private Deck _player1Deck;
    private Deck _player2Deck;

    public GamePhase CurrentPhase;

    //TODO: Make another data type? Maybe just skip the dictionaries?
    private Dictionary<ulong, Dictionary<GameZoneType, GameZone_Base>> GameZonesByTypeByPlayer;
    public short CurrentTurn;
    private int _registeredDeckCount;
    private int _postMulliganPlayerCount;

    public bool IsValidPlayer(ulong playerId) => playerId == Player1Id || playerId == Player2Id;

    public GameStateManager()
    {
        Debug.Log("GameStateManager::GameStateManager");

        CurrentPhase = GamePhase.Setup;

        GameZonesByTypeByPlayer = new Dictionary<ulong, Dictionary<GameZoneType, GameZone_Base>>();

        _registeredDeckCount = 0;

        CurrentTurn = 0;

        MonitorDeckRegistration();

        //RulesEngine.Instance.PlayerDeathEvent += RulesEngine_PlayerDeathEvent;
    }

    public void DrawCards(ulong playerId, int amountToDraw, int sourceCardMatchId)
    {
        Debug.Log("GameStateManager::DrawCards");

        if (GameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return;
        }
        if (GameZonesByTypeByPlayer[playerId].ContainsKey(GameZoneType.Deck) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a deck zone for player {playerId}.");
            return;
        }

        GameZone_Deck deck = (GameZone_Deck)GameZonesByTypeByPlayer[playerId][GameZoneType.Deck];
        List<int> drawnCards = new List<int>();
        for (int i = 0; i < amountToDraw; i++)
        {
            int topCardId = deck.GetTopCardMatchID();
            Debug.Log($"GameStateManager: Top Card_Base Match ID: {topCardId}.");

            drawnCards.Add(topCardId);
            if (topCardId == RulesEngine.INVALID_CARD_ID)
            {
               //TODO: Shuffle discard into library
            }

            MoveCardFromZoneToZone(playerId, topCardId, GameZoneType.Deck, GameZoneType.Hand);
        }
    }

    public bool RegisterPlayer(ulong playerId, Deck deck)
    {
        Debug.Log("GameStateManager::RegisterPlayer");

        bool registrationResult = ConfigurePlayer(playerId);
        Debug.Log($"GameStateManager: Registration result {registrationResult}.");

        if (registrationResult)
        {
            Dictionary<GameZoneType, GameZone_Base> GameZone_ForPlayer = new Dictionary<GameZoneType, GameZone_Base>();

            Debug.Log("GameStateManager: Adding Battlefield Zone.");
            GameZone_ForPlayer.Add(GameZoneType.Battlefield, new GameZone_Battlefield());

            Debug.Log("GameStateManager: Adding Break Zone.");
            GameZone_ForPlayer.Add(GameZoneType.Break, new GameZone_Break());

            Debug.Log("GameStateManager: Adding Deck Zone.");
            GameZone_ForPlayer.Add(GameZoneType.Deck, new GameZone_Deck());

            Debug.Log("GameStateManager: Adding Discard Zone.");
            GameZone_ForPlayer.Add(GameZoneType.Discard, new GameZone_Discard());

            Debug.Log("GameStateManager: Adding Hand Zone.");
            GameZone_ForPlayer.Add(GameZoneType.Hand, new GameZone_Hand());

            Debug.Log("GameStateManager: Adding Stage Zone.");
            GameZone_ForPlayer.Add(GameZoneType.Stage, new GameZone_Stage());

            Debug.Log("GameStateManager: Adding Support Zone.");
            GameZone_ForPlayer.Add(GameZoneType.Support, new GameZone_Support());

            GameZonesByTypeByPlayer.Add(playerId, GameZone_ForPlayer);

            Debug.Log("GameStateManager: Registering deck.");
            RulesEngine.Instance.GetCardManager().RegisterDeckForPlayer(playerId, deck);
        }

        foreach (var GameZone_ in GameZonesByTypeByPlayer[playerId])
        {
            GameZone_.Value.OwningPlayerId = playerId;
        }

        return registrationResult;
    }

    public bool ConfigurePlayer(ulong playerId)
    {
        Debug.Log("GameStateManager::ConfigurePlayer");

        if (HasPlayer1BeenRegistered == false)
        {
            Debug.Log("GameState: Registering Player 1 as: " + playerId);

            Player1Id = playerId;
            HasPlayer1BeenRegistered = true;
            return true;
        }
        else if (HasPlayer2BeenRegistered == false)
        {
            Debug.Log("GameState: Registering Player 2 as: " + playerId);

            Player2Id = playerId;
            HasPlayer2BeenRegistered = true;
            return true;
        }
        else
        {
            Debug.LogError("Attempting to register a third participant. Player 1 ID: " + Player1Id + ". Player 2 ID: " + Player2Id + ". Invalid player ID: " + playerId);
        }

        Debug.Log("GameState: Unable to regiseter " + playerId + " as a Player.");
        return false;
    }

    public bool RegisterDeckForPlayer(ulong playerId, Deck deck)
    {
        Debug.Log("GameStateManager::RegisterDeckForPlayer");

        //TODO: I should not do this here, but instead have some kind of event system that handles this
        _registeredDeckCount++;
        Debug.Log($"Registered {_registeredDeckCount} decks.");

        if (playerId == Player1Id)
        {
            Debug.Log($"GameState: Registering deck {deck.Name} for player {playerId}.");
            _player1Deck = deck;
            return true;
        }
        else if (playerId == Player2Id)
        {
            Debug.Log($"GameState: Registering deck {deck.Name} for player {playerId}.");
            _player2Deck = deck;
            return true;
        }
        else
        {
            Debug.Log($"GameState: Could not register deck {deck.Name} for a player, as the ID {playerId} is not associated with either player.");
        }

        return false;
    }

    public ulong GetOpponentId(ulong playerId)
    {
        Debug.Log("GameStateManager::GetOpponentId");

        if (!IsValidPlayer(playerId))
        {
            Debug.LogWarning("This is not a valid player");
            return RulesEngine.INVALID_PLAYER_ID;
        }

        return playerId == Player1Id ? Player2Id : Player1Id;
    }

    private async Task MonitorDeckRegistration()
    {
        Debug.Log("GameStateManager::MonitorDeckRegistration");

        while (true)
        {
            if (_registeredDeckCount >= 2)
            {
                RegisterMatch();
                StartMulligans();

                break;
            }

            await Task.Delay(500);
        }
    }

    private void RulesEngine_PlayerDeathEvent(ulong deadPlayerId)
    {
        Debug.Log("GameStateManager::RulesEngine_PlayerDeathEvent");
        EndMatch(deadPlayerId);
    }

    private async void RegisterMatch()
    {
        Debug.Log("GameStateManager::RegisterMatch");
        //TODO: Register on the database    
    }

    private async void EndMatch(ulong losingPlayerId)
    {
        Debug.Log("GameStateManager::EndMatch");
        //TODO: Update database
    }

    public Deck GetDeckForPlayer(ulong playerId)
    {
        Debug.Log("GameStateManager::GetDeckForPlayer");
        return playerId == Player1Id ? _player1Deck : _player2Deck;
    }

    public GameZoneType GetZoneCardIsPresentIn(int cardMatchId)
    {
        Debug.Log("GameStateManager::GetZoneCardIsPresentIn");

        foreach (KeyValuePair<ulong, Dictionary<GameZoneType, GameZone_Base>> kvp in GameZonesByTypeByPlayer)
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

        foreach (KeyValuePair<ulong, Dictionary<GameZoneType, GameZone_Base>> kvp in GameZonesByTypeByPlayer)
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
        return RulesEngine.INVALID_PLAYER_ID;
    }

    public IReadOnlyList<int> GetAllCardMatchIdsForPlayer(ulong playerId)
    {
        Debug.Log("GameStateManager::GetAllCardMatchIdsForPlayer");

        if (GameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return new List<int>();
        }

        List<int> allCookieIds = new List<int>();

        foreach (KeyValuePair<GameZoneType, GameZone_Base> zone in GameZonesByTypeByPlayer[playerId])
        {
            allCookieIds.AddRange(zone.Value.GetCards());
        }

        return allCookieIds;
    }

    public IReadOnlyList<int> GetCardsInZone(ulong playerId, GameZoneType zone)
    {
        Debug.Log("GameStateManager::GetCardsInZone");

        if (GameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return new List<int>();
        }
        if (GameZonesByTypeByPlayer[playerId].ContainsKey(zone) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a {zone.ToString()} zone for player {playerId}.");
            return new List<int>();
        }

        return GameZonesByTypeByPlayer[playerId][zone].GetCards();
    }

    public List<int> GetCookiesPlayerControls(ulong playerId)
    {
        Debug.Log("GameStateManager::GetCookiesPlayerControls");

        if (GameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return new List<int>();
        }
        if (GameZonesByTypeByPlayer[playerId].ContainsKey(GameZoneType.Battlefield) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a Battlefield zone for player {playerId}.");
            return new List<int>();
        }

        return new List<int>(GameZonesByTypeByPlayer[playerId][GameZoneType.Battlefield].GetCards());
    }

    public void MoveCardFromZoneToZone(ulong playerId, int cardMatchId, GameZoneType sourceZone, GameZoneType destinationZone)
    {
        Debug.Log("GameStateManager::MoveCardFromZoneToZone");

        if (cardMatchId == RulesEngine.INVALID_CARD_ID)
        {
            Debug.Log("cardMatchId is invalid");
            return;
        }
        if (GameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return;
        }
        if (((sourceZone == GameZoneType.Invalid && CurrentPhase == GamePhase.Setup) == false) && GameZonesByTypeByPlayer[playerId].ContainsKey(sourceZone) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a {sourceZone.ToString()} zone for player {playerId}.");
            return;
        }
        if (GameZonesByTypeByPlayer[playerId].ContainsKey(destinationZone) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a {destinationZone.ToString()} zone for player {playerId}.");
            return;
        }
        
        GameZonesByTypeByPlayer[playerId][sourceZone].RemoveCard(cardMatchId);
        GameZonesByTypeByPlayer[playerId][destinationZone].AddCard(cardMatchId);

        RulesEngine.Instance.BroadcastCardMovedFromZoneToZone(playerId, cardMatchId, sourceZone, destinationZone);
    }

    public bool CanAddCardToZone(ulong playerId, int cardMatchId, GameZoneType zone)
    {
        Debug.Log("GameStateManager::CanAddCardToZone");

        if (GameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return false;
        }
        if (GameZonesByTypeByPlayer[playerId].ContainsKey(zone) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a {zone.ToString()} zone for player {playerId}.");
            return false;
        }
        if (GameZonesByTypeByPlayer[playerId][zone].CanAddCardToZone(cardMatchId) == false)
        {
            Debug.Log($"GameStateManager: Unable to add {cardMatchId} to {zone.ToString()} zone for player {playerId}.");
            return false;
        }

        return true;
    }

    public void ShuffleDeckForPlayer(ulong playerId)
    {
        if (GameZonesByTypeByPlayer.ContainsKey(playerId) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain an entry for {playerId}.");
            return;
        }
        if (GameZonesByTypeByPlayer[playerId].ContainsKey(GameZoneType.Deck) == false)
        {
            Debug.Log($"GameStateManager: GameZonesByTypeByPlayer does not contain a Deck zone for player {playerId}.");
            return;
        }

        Debug.Log($"Player {playerId}'s deck is being shuffled.");
        ((GameZone_Deck)GameZonesByTypeByPlayer[playerId][GameZoneType.Deck]).Shuffle();
    }

    public void StartMulligans()
    {
        Debug.Log("GameStateManager::StartMulligans");

        //TODO: Have to ensure at least one Cookie is drawn. Either: Draw 5 > check for Cookie, if none tutor first Cookie  OR Draw 6 > Check for Cookie, if none auto-mulligan and repeat
        if (GameZonesByTypeByPlayer.ContainsKey(Player1Id))
        {
            ShuffleDeckForPlayer(Player1Id);

            Debug.Log($"Player {Player1Id} is drawing 4 cards.");
            DrawCards(Player1Id, 6, RulesEngine.GAME_ACTION);
        }

        if (GameZonesByTypeByPlayer.ContainsKey(Player2Id))
        {
            ShuffleDeckForPlayer(Player2Id);

            Debug.Log($"Player {Player2Id} is drawing 4 cards.");
            DrawCards(Player2Id, 6, RulesEngine.GAME_ACTION);
        }

        RulesEngine.Instance.BroadcastMulligansStartEvent();

    }

    public void PlayerRefusesMulligan(ulong playerId)
    {
        Debug.Log("GameStateManager::PlayerRefusesMulligan");

        _postMulliganPlayerCount++;
        if (_postMulliganPlayerCount >= 2)
        {
            EndMulligan();
        }
    }

    public void PlayerRequestsMulligan(ulong playerId)
    {
        Debug.Log("GameStateManager::PlayerRequestsMulligan");

        foreach (var cardId in GetCardsInZone(playerId, GameZoneType.Hand))
        {
            Debug.Log($"Putting Card_Base Match ID {cardId} back into deck.");
            MoveCardFromZoneToZone(playerId, cardId, GameZoneType.Hand, GameZoneType.Deck);
        }

        ShuffleDeckForPlayer(playerId);
        DrawCards(playerId, 6, RulesEngine.GAME_ACTION);

        _postMulliganPlayerCount++;
        if (_postMulliganPlayerCount >= 2)
        {
            EndMulligan();
        }
    }

    public void EndMulligan()
    {
        Debug.Log("GameStateManager::EndMulligan");

        RulesEngine.Instance.BroadcastMulligansEndEvent();
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("GameStateManager::StartGame");

        RulesEngine.Instance.BroadcastGameStartEvent();

        StartRound();
    }

    public void StartRound()
    {
        Debug.Log("GameStateManager::StartRound");

        //TODO: Enter the Active Phase, tick up turn counter, etc
        CurrentPhase = GamePhase.Active;
    }

    public void EndRound()
    {
        Debug.Log("GameStateManager::EndRound");

        //TODO: Start a new round
        CurrentPhase = GamePhase.End;
    }

    public void DealCombatDamageToCookie(int sourceCardMatchId, int targetCardMatchId, int damageAmount)
    {
        Debug.Log("GameStateManager::DealCombatDamageToCookie");

        if (damageAmount <= 0)
        {
            Debug.Log($"Cannot deal {damageAmount} damage");
            return;
        }

        Card_Base targetCard = RulesEngine.Instance.GetCardManager().GetCardByMatchId(targetCardMatchId);
        targetCard.TakeDamage(damageAmount);

        RulesEngine.Instance.GetCardManager().GenericUpdateCard(targetCard);
    }

    public void DealNonCombatDamageToCookie(int sourceCardMatchId, int targetCardMatchId, int damageAmount)
    {
        Debug.Log("GameStateManager::DealNonCombatDamageToCookie");

        if (damageAmount <= 0)
        {
            Debug.Log("Damage was reduced to 0");
            return;
        }

        Card_Base targetCard = RulesEngine.Instance.GetCardManager().GetCardByMatchId(targetCardMatchId);
        targetCard.TakeDamage(damageAmount);

        RulesEngine.Instance.GetCardManager().GenericUpdateCard(targetCard);
    }
}
