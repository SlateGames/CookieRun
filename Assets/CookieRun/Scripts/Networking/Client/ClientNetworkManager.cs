using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using System;

public class ClientNetworkManager : MonoBehaviour
{
    [SerializeField] private NetworkManager networkManager;

    [SerializeField] private string defaultServerAddress = "127.0.0.1";
    [SerializeField] private ushort defaultServerPort = 7777;

    private bool _initialized;

    public event Action<string> OnConnectionStatusChanged;
    public event Action<string> OnConnectionError;

    private Action<NetworkManager.ConnectionApprovalRequest, NetworkManager.ConnectionApprovalResponse> _approvalCallback;

    private void Start()
    {
        Debug.Log("ClientNetworkManager::Start");

        if (networkManager == null)
        {
            Debug.LogError("NetworkManager reference not set in ClientNetworkManager!");
            enabled = false;
            return;
        }

        Initialize();
    }

    private void Initialize()
    {
        Debug.Log("ClientNetworkManager::Initialize");

        if (_initialized)
        {
            return;
        }

        networkManager.OnClientConnectedCallback += OnClientConnected;
        networkManager.OnClientDisconnectCallback += OnClientDisconnected;

        _initialized = true;

        Debug.Log("ClientNetworkManager initialized");
    }

    public void ConnectToServer(string ipAddress = null, ushort? port = null)
    {
        Debug.Log("ClientNetworkManager::ConnectToServer");

        if (!_initialized)
        {
            OnConnectionError?.Invoke("ClientNetworkManager not initialized!");
            return;
        }

        try
        {
            var transport = networkManager.GetComponent<UnityTransport>();
            if (transport == null)
            {
                OnConnectionError?.Invoke("Transport component not found");
                return;
            }

            transport.ConnectionData.Address = ipAddress ?? defaultServerAddress;
            transport.ConnectionData.Port = port ?? defaultServerPort;

            OnConnectionStatusChanged?.Invoke("Connecting to server...");

            if (!networkManager.StartClient())
            {
                OnConnectionError?.Invoke("Failed to start client");
                return;
            }

        }
        catch (Exception ex)
        {
            OnConnectionError?.Invoke($"Failed to connect to server: {ex.Message}");
        }
    }

    private void OnClientConnected(ulong clientId)
    {
        Debug.Log("ClientNetworkManager::OnClientConnected");
        OnConnectionStatusChanged?.Invoke($"Connected to server! Client ID: {clientId}");
    }

    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log("ClientNetworkManager::OnClientDisconnected");

        OnConnectionStatusChanged?.Invoke("Disconnected from server. Reason: " + NetworkManager.Singleton.DisconnectReason);

        // Only unsubscribe if **this** is the local client disconnecting
        if (clientId == networkManager.LocalClientId)
        {
            Debug.Log("Local client disconnected — unsubscribing from ConnectionApprovalCallback.");

            if (_approvalCallback != null)
            {
                networkManager.ConnectionApprovalCallback -= _approvalCallback;
                _approvalCallback = null;
            }
        }
    }


    private void OnDestroy()
    {
        Debug.Log("ClientNetworkManager::OnDestroy");

        if (networkManager != null)
        {
            networkManager.OnClientConnectedCallback -= OnClientConnected;
            networkManager.OnClientDisconnectCallback -= OnClientDisconnected;
        }
    }

}
