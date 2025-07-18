using UnityEngine;
public enum GameQueue
{
    Singleplayer,
    Competitive,
    LocalHost,
    LocalClient
}

public class ClientStorageManager
{
    //TODO: Should we be using PlayerPrefs for local storage?
    public ConnectionDataStorageManager ConnectionDataStorageManager;
    public ClientSettingsDataManager ClientSettingsDataManager;
    //public CardDataManager CardDataManager;
    //public SetDataManager SetDataManager;
    //public ImageDataManager ImageDataManager;
    public DeckDataManager DeckDataManager;

    public const string ClientVersion = "v0.1.0";
    public string ChosenDeckID = "";

    private static readonly object _lock = new object();
    private static ClientStorageManager _instance;
    public static ClientStorageManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    Debug.Log("_instance is null. Stack trace:" + new System.Diagnostics.StackTrace(true).ToString());
                    _instance = new ClientStorageManager();
                }
                return _instance;
            }
        }
    }


    private ClientStorageManager()
    {
        Debug.Log("ClientStorageManager::ClientStorageManager");

        ConnectionDataStorageManager = new ConnectionDataStorageManager();
        ClientSettingsDataManager = new ClientSettingsDataManager();
        //CardDataManager = new CardDataManager();
        //SetDataManager = new SetDataManager();
        //ImageDataManager = new ImageDataManager();
        DeckDataManager = new DeckDataManager();
    }
}