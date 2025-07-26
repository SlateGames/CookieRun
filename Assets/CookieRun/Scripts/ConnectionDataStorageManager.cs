using UnityEngine;
using System.Text.RegularExpressions;

public class ConnectionDataStorageManager
{
    private const string IP_PREF_KEY = "ServerIP";
    private const string PORT_PREF_KEY = "ServerPort";
    private const string GAME_QUEUE_KEYE = "GameQueue";
    private const int MIN_PORT = 1024;
    private const int MAX_PORT = 65535;
    private const string IP_PATTERN = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

    public void SaveGameQueue(GameQueue gameQueue)
    {
        Debug.Log("ConnectionDataStorageManager::SaveGameQueue");

        try
        {
            PlayerPrefs.SetInt(GAME_QUEUE_KEYE, (int)gameQueue);
            PlayerPrefs.Save();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error saving connection details: {ex.Message}");
        }
    }

    public GameQueue ReadGameQueue()
    {
        Debug.Log("ConnectionDataStorageManager::ReadGameQueue");

        try
        {
            GameQueue gameQueue = (GameQueue)PlayerPrefs.GetInt(GAME_QUEUE_KEYE, 0);
            return gameQueue;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error loading connection details: {ex.Message}");
            return GameQueue.Singleplayer;
        }
    }

    public void SaveConnectionDetails(string ip, int port)
    {
        Debug.Log("ConnectionDataStorageManager::SaveConnectionDetails");

        try
        {
            if (IsValidIP(ip) == false)
            {
                Debug.LogError($"Invalid IP address format: {ip}");
                return;
            }
            if (IsValidPort(port) == false)
            {
                Debug.LogError($"Invalid port number: {port}. Must be between {MIN_PORT} and {MAX_PORT}");
                return;
            }

            PlayerPrefs.SetString(IP_PREF_KEY, ip);
            PlayerPrefs.SetInt(PORT_PREF_KEY, port);
            PlayerPrefs.Save();

            Debug.Log($"Saved connection details - IP: {ip}, Port: {port}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error saving connection details: {ex.Message}");
        }
    }

    public (string ip, int port) LoadConnectionDetails()
    {
        Debug.Log("ConnectionDataStorageManager::LoadConnectionDetails");

        try
        {
            string ip = PlayerPrefs.GetString(IP_PREF_KEY, "127.0.0.1");
            int port = PlayerPrefs.GetInt(PORT_PREF_KEY, 7777);

            Debug.Log($"Loaded connection details - IP: {ip}, Port: {port}");
            return (ip, port);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error loading connection details: {ex.Message}");
            return ("127.0.0.1", 7777);
        }
    }

    public void ClearConnectionDetails()
    {
        Debug.Log("ConnectionDataStorageManager::ClearConnectionDetails");

        try
        {
            PlayerPrefs.DeleteKey(IP_PREF_KEY);
            PlayerPrefs.DeleteKey(PORT_PREF_KEY);
            PlayerPrefs.Save();
            Debug.Log("Cleared connection details");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error clearing connection details: {ex.Message}");
        }
    }

    private bool IsValidIP(string ip)
    {
        Debug.Log("ConnectionDataStorageManager::IsValidIP");

        if (string.IsNullOrWhiteSpace(ip))
        {
            return false;
        }

        return Regex.IsMatch(ip, IP_PATTERN);
    }

    private bool IsValidPort(int port)
    {
        Debug.Log("ConnectionDataStorageManager::IsValidPort");
        return port >= MIN_PORT && port <= MAX_PORT;
    }
}