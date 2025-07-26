using UnityEngine;
using Unity.Netcode;
using System;
using System.Collections.Generic;
using System.Linq;

//TODO: Make a base class for this and the Spectator? Things like the OnNetworkSpawn and InitComps could be defined there 

public class ClientServerBridge : NetworkBehaviour
{
    public event Action TestAction;
    public event Action<GamePhase> EnterGamePhase;
    public event Action<GamePhase> ExitGamePhase;

    public override void OnNetworkSpawn()
    {
        Debug.Log("ClientServerBridge::OnNetworkSpawn");

        base.OnNetworkSpawn();

        Debug.Log($"Player spawned. IsOwner: {IsOwner}, IsClient: {IsClient}, IsServer: {IsServer}");

        Initialize();
    }

    public async void Initialize()
    {
        Debug.Log("ClientServerBridge::Initialize");

        if (IsOwner)
        {
            Debug.Log($"ClientServerBridge: Spawned for Player {OwnerClientId}");

            HandleSetupCompleted();

            Deck deck = ClientStorageManager.Instance.DeckDataManager.GetDeck(ClientStorageManager.Instance.ChosenDeckID);
            RegisterPlayerServerRpc(OwnerClientId, deck);
        }
        if (IsServer)
        {
            Debug.Log($"ClientServerBridge: Spawned for Player {OwnerClientId}");
            SubscribeToServerEvents();
        }
    }

    private async void SubscribeToServerEvents()
    {
        Debug.Log("ClientServerBridge::SubscribeToServerEvents");

        RulesEngine.Instance.TestAction += RulesEngine_TestAction;

        RulesEngine.Instance.EnterGamePhaseEvent += RulesEngine_EnterGamePhaseEvent;
        RulesEngine.Instance.ExitGamePhaseEvent += RulesEngine_ExitGamePhaseEvent;
    }

    private void RulesEngine_EnterGamePhaseEvent(GamePhase gamePhase)
    {
        Debug.Log("ClientServerBridge::RulesEngine_EnterGamePhaseEvent");
    }
    [ClientRpc]
    private void EnterGamePhaseClientRpc(GamePhase gamePhase)
    {
        Debug.Log("ClientServerBridge::EnterGamePhaseClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        EnterGamePhase?.Invoke(gamePhase);
    }

    private void RulesEngine_ExitGamePhaseEvent(GamePhase gamePhase)
    {
        Debug.Log("ClientServerBridge::RulesEngine_ExitGamePhaseEvent");
    }
    [ClientRpc]
    private void ExitGamePhaseClientRpc(GamePhase gamePhase)
    {
        Debug.Log("ClientServerBridge::ExitGamePhaseClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        ExitGamePhase?.Invoke(gamePhase);
    }

    //TODO: Revert the deck back to a deck id once the database is up
    [ServerRpc]
    public void RegisterPlayerServerRpc(ulong playerId, Deck deck)
    {
        Debug.Log("ClientServerBridge::RegisterPlayerServerRpc");
        RulesEngine.Instance.GetGameStateManager().RegisterPlayer(playerId, deck);
    }

    private void RulesEngine_TestAction()
    {
        TestActionClientRpc();
    }

    [ClientRpc]
    private void TestActionClientRpc()
    {
        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        TestAction?.Invoke();
    }

    [ServerRpc]
    public void PassPriorityServerRpc(ulong passingPlayerId)
    {
        Debug.Log("ClientServerBridge::PassPriorityServerRpc");
        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        if(RulesEngine.Instance.GetGameStateManager().GetActivePlayerId() != passingPlayerId)
        {
            Debug.Log($"Player {passingPlayerId} is not the active player");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().PassPriority(passingPlayerId);
    }

    private void HandleSetupCompleted()
    {
        Debug.Log("ClientServerBridge::HandleSetupCompleted");
        FindObjectOfType<ClientUIController>().Initialize(OwnerClientId, this);
    }
}