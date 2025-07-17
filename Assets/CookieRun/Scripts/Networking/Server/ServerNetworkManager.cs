using Unity.Netcode;
using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Services.Multiplay;
using System.Threading;
using System.Threading.Tasks;
using Unity.Services.Core;
using System.Collections;

public class ServerNetworkManager : NetworkManager
{
    public static readonly int SERVER_VERSION_MAJOR = 0;
    public static readonly int SERVER_VERSION_MINOR = 1;
    public static readonly int SERVER_VERSION_PATCH = 0;
    public static readonly int SERVER_VERSION_BUILD = 0;
    public static readonly string SERVER_VERSION_SPECIAL = "";

    public GameObject rulesEnginePrefab;

    private static readonly int SERVER_SHUTDOWN_DELAY = 5;

    //TODO: Track Players vs Spectators. Then I can shutdown the server when all players have left.
    private HashSet<ulong> connectedClients = new HashSet<ulong>();
    private CancellationTokenSource _cancellationTokenSource;
    IServerQueryHandler _ServerQueryHandler;
    private Coroutine quitCoroutine;

    public void Initialize()
    {
        Debug.Log("ServerNetworkManager::Initialize");

        NetworkConfig.ConnectionApproval = true;
        ConnectionApprovalCallback += ApproveConnection;
        OnClientConnectedCallback += OnClientConnected;
        OnClientDisconnectCallback += OnClientDisconnected;
        OnServerStarted += HandleServerStarted;

        Debug.Log("ServerNetworkManager initialized with the following config:");
        Debug.Log($"- Connection Approval: {NetworkConfig.ConnectionApproval}");
        Debug.Log($"- Player Prefab: {(NetworkConfig.PlayerPrefab != null ? NetworkConfig.PlayerPrefab.name : "None")}");
        Debug.Log($"- Network Prefabs Count: {NetworkConfig.Prefabs.Prefabs.Count}");
    }

    private void HandleServerStarted()
    {
        Debug.Log("ServerNetworkManager::HandleServerStarted");

        var rulesEngineInstance = Instantiate(FindObjectOfType<ServerNetworkPrefabs>().rulesEnginePrefab);
        var dataSyncNetwork = rulesEngineInstance.GetComponent<NetworkObject>();
        if (dataSyncNetwork != null)
        {
            dataSyncNetwork.Spawn();

            Debug.Log($"Spawned RulesEngine for server and client");
            Debug.Log($"Server Version: {SERVER_VERSION_MAJOR}.{SERVER_VERSION_MINOR}.{SERVER_VERSION_PATCH}.{SERVER_VERSION_BUILD}{(string.IsNullOrEmpty(SERVER_VERSION_SPECIAL) ? "" : "-" + SERVER_VERSION_SPECIAL)}");

            BeginServerUpkeep();
        }
        else
        {
            Debug.LogError("NetworkObject component missing from Dedicated Server prefab!");
        }
    }

    private async void BeginServerUpkeep()
    {
        Debug.Log("ServerNetworkManager::BeginServerUpkeep");

        if (Application.isBatchMode == false)
        {
            Debug.Log("Server is in singleplayer mode.");
            return;
        }

        await UnityServices.InitializeAsync();

        var multiplayEventCallbacks = new MultiplayEventCallbacks();
        multiplayEventCallbacks.Allocate += MultiplayEventCallbacks_Allocate;
        multiplayEventCallbacks.Deallocate += MultiplayEventCallbacks_Deallocate;
        multiplayEventCallbacks.Error += MultiplayEventCallbacks_Error;
        multiplayEventCallbacks.SubscriptionStateChanged += MultiplayEventCallbacks_SubscriptionStateChanged;

        _ServerQueryHandler = await MultiplayService.Instance.StartServerQueryHandlerAsync((ushort)10, "ChronoCCGGameServer" + Guid.NewGuid(), "Competitive", "0", "Lab");

        _cancellationTokenSource = new CancellationTokenSource();
        ServerQueryLoop(_cancellationTokenSource.Token);

        await MultiplayService.Instance.SubscribeToServerEventsAsync(multiplayEventCallbacks);
    }

    private void MultiplayEventCallbacks_Allocate(MultiplayAllocation allocation)
    {
        Debug.Log("ServerNetworkManager::MultiplayEventCallbacks_Allocate");
        Debug.Log($"Allocation Event ID: {allocation.EventId}, Allocation Server ID: {allocation.ServerId}, Allocation Allocation ID: {allocation.AllocationId}.");
    }

    private void MultiplayEventCallbacks_Deallocate(MultiplayDeallocation deallocation)
    {
        Debug.Log("ServerNetworkManager::MultiplayEventCallbacks_Deallocate");
        Debug.Log($"Deallocation Event ID: {deallocation.EventId}, Deallocation Server ID: {deallocation.ServerId}, Deallocation Allocation ID: {deallocation.AllocationId}.");
    }

    private void MultiplayEventCallbacks_Error(MultiplayError error)
    {
        Debug.Log("ServerNetworkManager::MultiplayEventCallbacks_Error");
        Debug.Log($"Error Reason: {error.Reason}, Error Detail: {error.Detail}.");
    }

    private void MultiplayEventCallbacks_SubscriptionStateChanged(MultiplayServerSubscriptionState subscriptionState)
    {
        Debug.Log("ServerNetworkManager::MultiplayEventCallbacks_SubscriptionStateChanged");
        Debug.Log($"Subscription State: {subscriptionState}.");
    }

    private void ApproveConnection(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        Debug.Log("ServerNetworkManager::ApproveConnection");

        try
        {
            Debug.Log("Processing connection approval for client");

            // Always approve for now
            response.Approved = true;
            response.CreatePlayerObject = false; // Manually spawn in OnClientConnected

            Debug.Log("Connection approved");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error in connection approval: {ex.Message}");
            response.Approved = false;
            response.Reason = "Internal server error";
        }
    }

    private void OnClientConnected(ulong clientId)
    {
        Debug.Log("ServerNetworkManager::OnClientConnected");

        if (connectedClients.Contains(clientId))
        {
            Debug.Log($"Client {clientId} already has a player spawned, skipping...");
            return;
        }

        Debug.Log($"Client {clientId} connected");

        try
        {
            if (NetworkConfig.PlayerPrefab == null)
            {
                Debug.LogError("Player prefab is not set!");
                return;
            }

            var playerInstance = Instantiate(NetworkConfig.PlayerPrefab);
            var networkObject = playerInstance.GetComponent<NetworkObject>();
            if (networkObject != null)
            {
                networkObject.SpawnAsPlayerObject(clientId, true);
                connectedClients.Add(clientId);
                Debug.Log($"Spawned player for client {clientId}");

                if (quitCoroutine != null)
                {
                    CancelQuitTimer();
                }
            }
            else
            {
                Debug.LogError("NetworkObject component missing from player prefab!");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error handling client connection: {ex.Message}");
        }
    }

    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log("ServerNetworkManager::OnClientDisconnected");

        bool wasActuallyConnected = connectedClients.Remove(clientId);
        if (!wasActuallyConnected)
        {
            Debug.LogWarning($"Client {clientId} disconnect callback called but client was already removed - ignoring duplicate call");
            return;
        }

        Debug.Log($"Client {clientId} disconnected");

        if (connectedClients.Count == 0)
        {
            if (quitCoroutine == null)
            {
                Debug.Log("No more clients are connected, closing the server");
                quitCoroutine = StartCoroutine(QuitAfterDelay());
            }
            else
            {
                Debug.Log("Client disconnected but quit timer already running");
            }
        }
    }

    private async Task ShutdownServer()
    {
        Debug.Log("ServerNetworkManager::ShutdownServer");

        if (Application.isBatchMode == false)
        {
            Debug.Log("Server is in singleplayer mode.");
            Shutdown();
            Destroy(gameObject);
            return;
        }

        try
        {
            //RulesEngine.Instance.BroadcastPlayerDeathEvent(RulesEngine.INVALID_PLAYER_ID);

            _cancellationTokenSource.Cancel();
            Shutdown();
            await MultiplayService.Instance.UnreadyServerAsync();

            await Task.Delay(1000);
            Application.Quit(0);

            await Task.Delay(2000);
            Environment.Exit(0);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error during server shutdown: {ex}");

            try
            {
                await MultiplayService.Instance.UnreadyServerAsync();
            }
            catch (Exception unreadyEx)
            {
                Debug.LogError($"Failed to unready server: {unreadyEx}");
            }

            Application.Quit(1);
            Environment.Exit(1);
        }
    }

    public void CancelQuitTimer()
    {
        Debug.Log("ServerNetworkManager::CancelQuitTimer");

        if (quitCoroutine != null)
        {
            StopCoroutine(quitCoroutine);
            quitCoroutine = null;
        }
    }

    private IEnumerator QuitAfterDelay()
    {
        Debug.Log("ServerNetworkManager::QuitAfterDelay");

        if (Application.isBatchMode)
        {
            yield return new WaitForSeconds(SERVER_SHUTDOWN_DELAY);
        }

        ShutdownServer();
    }

    async Task ServerQueryLoop(CancellationToken cancellationToken)
    {
        Debug.Log("ServerNetworkManager::ServerQueryLoop");

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_ServerQueryHandler != null)
                {
                    _ServerQueryHandler.UpdateServerCheck();
                }
                else
                {
                    Debug.LogError("ServerQueryHandler is NULL! Server will fail Unity Multiplay's health check.");
                }

                await Task.Delay(500, cancellationToken);
            }
        }
        catch (TaskCanceledException)
        {
            Debug.Log("ServerQueryLoop was cancelled gracefully.");
        }
        catch (Exception ex)
        {
            Debug.LogError("Unexpected exception in ServerQueryLoop.");
            Debug.LogError($"Exception: {ex}");
            Debug.LogError($"Message: {ex.Message}");
        }
    }

    private void OnDestroy()
    {
        Debug.Log("ServerNetworkManager::OnDestroy");

        _cancellationTokenSource?.Cancel();

        if (quitCoroutine != null)
        {
            StopCoroutine(quitCoroutine);
            quitCoroutine = null;
        }

        ConnectionApprovalCallback -= ApproveConnection;
        OnClientConnectedCallback -= OnClientConnected;
        OnClientDisconnectCallback -= OnClientDisconnected;
    }
}
