using UnityEngine;
using Unity.Netcode;
using System;

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

            //Register player and deck with the server
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