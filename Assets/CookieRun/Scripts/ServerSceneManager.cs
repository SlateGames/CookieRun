using System;
using System.Collections;
using UnityEngine;

public class ServerSceneManager : MonoBehaviour
{
    [SerializeField] private ServerNetworkManager networkManager;
    [SerializeField] private bool startServerOnAwake = true;
    [SerializeField] private int serverPort = 7777;

    private void Start()
    {
        Debug.Log("ServerSceneManager::Start");

        if (networkManager == null)
        {
            Debug.LogError("NetworkManager reference not set in ServerSceneManager!");
            return;
        }

        try
        {
            StartCoroutine(Intialize());
        }
        catch (Exception ex)
        {
            Debug.LogError("Error while intilizaing server: " + ex);
        }
    }

    private IEnumerator Intialize()
    {
        var transport = networkManager.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>();
        if (transport != null)
        {
            transport.ConnectionData.Port = (ushort)serverPort;
            Debug.Log($"Server port set to: {serverPort}");
        }

        yield return null;

        networkManager.Initialize();
        bool isHostMode = !Application.isBatchMode;

        if (startServerOnAwake)
        {
            if (isHostMode)
            {
                if (networkManager.StartHost())
                {
                    Debug.Log("Host started successfully (Server + Client)");
                }
                else
                {
                    Debug.LogError("Failed to start host");
                }
            }
            else
            {
                if (networkManager.StartServer())
                {
                    Debug.Log("Dedicated Server started successfully");
                }
                else
                {
                    Debug.LogError("Failed to start dedicated server");
                }
            }
        }
    }
}