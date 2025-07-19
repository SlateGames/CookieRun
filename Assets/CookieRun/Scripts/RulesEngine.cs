using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class RulesEngine : NetworkBehaviour
{
    public const int INVALID_CARD_ID = 99999;

    public static RulesEngine Instance { get; private set; }

    public event Action TestAction;
    public event Action<ulong> DeckShuffledEvent;

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
    }

    private IEnumerator FireTestActionAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("RulesEngine::Firing TestAction after 5 seconds");
        TestAction?.Invoke();
    }

    public void BroadcastDeckShuffledEvent(ulong playerId)
    {
        Debug.Log("RulesEngine::BroadcastDeckShuffledEvent");
        DeckShuffledEvent?.Invoke(playerId);
    }
}
