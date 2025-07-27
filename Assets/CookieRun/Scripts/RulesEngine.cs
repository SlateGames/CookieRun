using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class RulesEngine : NetworkBehaviour
{
    public static RulesEngine Instance { get; private set; }

    private GameStateManager _gameStateManager;
    private GameZoneManager _gameZoneManager;
    private CardManager _cardManager;

    public event Action TestAction;
    public event Action<DeckDataPayload> DeckRegisteredForPlayerEvent;
    public event Action<ulong> DeckShuffledEvent;
    public event Action<ulong, string, int, GameZoneType, GameZoneType> CardChangeZoneEvent;
    public event Action MulligansStartEvent;
    public event Action MulligansEndEvent;
    public event Action GameStartEvent;
    public event Action<ulong> NewActivePlayerEvent;
    public event Action<ulong, GamePhase> PlayerPlayerEnterGamePhaseEvent;
    public event Action<ulong, GamePhase> PlayerPlayerExitGamePhaseEvent;

    public GameStateManager GetGameStateManager()
    {
        return _gameStateManager;
    }
    public GameZoneManager GetGameZoneManager()
    {
        return _gameZoneManager;
    }
    public CardManager GetCardManager()
    {
        return _cardManager;
    }

    public override void OnNetworkSpawn()
    {
        Debug.Log("RulesEngine::OnNetworkSpawn");

        if (Instance == null)
        {
            Instance = this;
        }

        if (IsServer)
        {
            Debug.Log("RulesEngine: Spawning server services");
            InitializeServerServices();

            TestAction?.Invoke();

            // Start coroutine to invoke TestAction after delay
            StartCoroutine(FireTestActionAfterDelay());
        }

        Debug.Log($"RulesEngine spawned. IsOwner: {IsOwner}, IsClient: {IsClient}, IsServer: {IsServer}");
    }

    private void InitializeServerServices()
    {
        Debug.Log("RulesEngine::InitializeServerServices");

        // Here is where we instantiate all the server classes
        Debug.Log("RulesEngine: Instantiating GameStateManager.");
        _gameStateManager = new GameStateManager();
        _gameStateManager.Initialize();

        Debug.Log("RulesEngine: Instantiating GameZoneManager.");
        _gameZoneManager = new GameZoneManager();

        Debug.Log("RulesEngine: Instantiating CardManager.");
        _cardManager = new CardManager();
    }

    private IEnumerator FireTestActionAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("RulesEngine::Firing TestAction after 5 seconds");
        TestAction?.Invoke();
    }
    public void BroadcastDeckRegisteredForPlayerEvent(DeckDataPayload deckRegistration)
    {
        Debug.Log("RulesEngine::BroadcastDeckRegisteredForPlayerEvent");
        DeckRegisteredForPlayerEvent?.Invoke(deckRegistration);
    }

    public void BroadcastDeckShuffledEvent(ulong playerId)
    {
        Debug.Log("RulesEngine::BroadcastDeckShuffledEvent");
        DeckShuffledEvent?.Invoke(playerId);
    }

    public void BroadcastPlayerPlayerEnterGamePhaseEvent(ulong playerId, GamePhase phase)
    {
        Debug.Log("RulesEngine::BroadcastPlayerPlayerEnterGamePhaseEvent");
        PlayerPlayerEnterGamePhaseEvent?.Invoke(playerId, phase);
    }
    
    public void BroadcastPlayerPlayerExitGamePhaseEvent(ulong playerId, GamePhase phase)
    {
        Debug.Log("RulesEngine::BroadcastPlayerPlayerExitGamePhaseEvent");
        PlayerPlayerExitGamePhaseEvent?.Invoke(playerId, phase);
    }

    public void BroadcastCardMovedFromZoneToZone(ulong playerId, string cardId, int cardMatchId, GameZoneType sourceZone, GameZoneType destinationZone)
    {
        Debug.Log("RulesEngine::BroadcastCardEnterZone");
        CardChangeZoneEvent?.Invoke(playerId, cardId, cardMatchId, sourceZone, destinationZone);
    }

    public void BroadcastMulligansStartEvent()
    {
        Debug.Log("RulesEngine::BroadcastMulligansStartEvent");
        MulligansStartEvent?.Invoke();
    }
    public void BroadcastMulligansEndEvent()
    {
        Debug.Log("RulesEngine::BroadcastMulligansEndEvent");
        MulligansEndEvent?.Invoke();
    }
    public void BroadcastGameStartEvent()
    {
        Debug.Log("RulesEngine::BroadcastGameStartEvent");
        GameStartEvent?.Invoke();
    }
}
