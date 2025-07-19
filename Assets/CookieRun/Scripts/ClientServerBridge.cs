using UnityEngine;
using Unity.Netcode;
using System;
using System.Collections.Generic;
using System.Linq;

//TODO: Make a base class for this and the Spectator? Things like the OnNetworkSpawn and InitComps could be defined there 

public class ClientServerBridge : NetworkBehaviour
{
    public event Action TestAction;

    #region SETUP
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

    private void HandleSetupCompleted()
    {
        Debug.Log("ClientServerBridge::HandleSetupCompleted");
        FindObjectOfType<ClientUIController>().Initialize(OwnerClientId, this);
    }
    #endregion
}