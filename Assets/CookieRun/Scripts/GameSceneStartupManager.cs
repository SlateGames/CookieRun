using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: General task. Clean up these classes. Remove the debug UI. Leave the data logging, but swap to the Chrono Logger. 
public class GameSceneStartupManager : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private float returnToMenuDelay = 3f;
    private ClientNetworkManager ClientNetworkManager;

    private void Start()
    {
        Debug.Log("GameSceneStartupManager::Start");

        switch (ClientStorageManager.Instance.ConnectionDataStorageManager.ReadGameQueue())
        {
            case GameQueue.Singleplayer:
                StartCoroutine(OfflineStartup());
                break;
            case GameQueue.Competitive:
                StartCoroutine(OnlineStartup());
                break;
        }
    }

    private IEnumerator OfflineStartup()
    {
        Debug.Log("GameSceneStartupManager::OfflineStartup");

        if (NetworkManager.Singleton == null)
        {
            Debug.LogError("NetworkManager not found!");
            yield break;
        }

        if (NetworkManager.Singleton.IsClient || NetworkManager.Singleton.IsServer)
        {
            Debug.LogWarning("NetworkManager is already running.");
            yield break;
        }

        yield return null;

        // Start Host Mode (Both Server & Client)
        if (NetworkManager.Singleton.StartHost())
        {
            Debug.Log("Host started successfully.");

            if (NetworkManager.Singleton.IsServer)
            {
                Debug.Log("[Server] Loading DedicatedServer...");
                yield return SceneManager.LoadSceneAsync("DedicatedServer", LoadSceneMode.Additive);
            }
        }
        else
        {
            Debug.LogError("Failed to start Host.");
        }
    }

    private IEnumerator OnlineStartup()
    {
        Debug.Log("GameSceneStartupManager::OnlineStartup");

        ClientNetworkManager = FindObjectOfType<ClientNetworkManager>();
        if (ClientNetworkManager == null)
        {
            ClientNetworkManager_OnConnectionError("ClientNetworkManager not found");
            yield break;
        }

        yield return null;

        ClientNetworkManager.OnConnectionError += ClientNetworkManager_OnConnectionError;
        ClientNetworkManager.OnConnectionStatusChanged += ClientNetworkManager_OnConnectionStatusChanged;

        InitiateConnection();
    }

    private void InitiateConnection()
    {
        Debug.Log("GameSceneStartupManager::InitiateConnection");

        var (ip, port) = ClientStorageManager.Instance.ConnectionDataStorageManager.LoadConnectionDetails();
        Debug.Log($"Attempting to connect to server at {ip}:{port}");

        ClientNetworkManager.ConnectToServer(ip, (ushort)port);
    }

    private void ClientNetworkManager_OnConnectionError(string errorMessage)
    {
        Debug.Log("GameSceneStartupManager::ClientNetworkManager_OnConnectionError");

        Debug.LogError($"Connection error: {errorMessage}");
        Invoke(nameof(ReturnToMainMenu), returnToMenuDelay);
    }

    private void ClientNetworkManager_OnConnectionStatusChanged(string statusMessage)
    {
        Debug.Log("GameSceneStartupManager::ClientNetworkManager_OnConnectionStatusChanged");
    }

    private void ReturnToMainMenu()
    {
        Debug.Log("GameSceneStartupManager::ReturnToMainMenu");
        SceneManager.LoadSceneAsync(mainMenuSceneName);
    }

    private void OnDestroy()
    {
        Debug.Log("GameSceneStartupManager::OnDestroy");
        if (ClientNetworkManager != null)
        {
            ClientNetworkManager.OnConnectionError -= ClientNetworkManager_OnConnectionError;
        }
    }
}