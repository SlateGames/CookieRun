using System.Text;
using System;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// All the data we would want to pass across the network.
/// </summary>
[Serializable]
public class UserData
{
    public string username; //name of the player
    public string userAuthId; //Auth Player ID
    public int winCount;
    public int elo;
    public GameInfo userGamePreferences; //The game info the player thought he was joining with

    public UserData(string username, string userAuthId, int winCount, int elo, GameInfo userGamePreferences)
    {
        this.username = username;
        this.userAuthId = userAuthId;
        this.winCount = winCount;
        this.elo = elo;
        this.userGamePreferences = userGamePreferences;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("UserData: ");
        sb.AppendLine($"- User Name:             {username}");
        sb.AppendLine($"- User Auth Id:          {userAuthId}");
        sb.AppendLine($"- User Game Preferences: {userGamePreferences}");
        return sb.ToString();
    }
}


/// <summary>
/// Subset of information that sets up the map and gameplay
/// </summary>
[Serializable]
public class GameInfo
{
    public GameQueue gameQueue;

    //QueueNames in the dashboard can be different than your local queue definitions (If you want nice names for them)
    const string k_MultiplaySingleplayerQueue = "singleplayer-queue";
    const string k_MultiplayCompetetiveQueue = "ranked-queue";
    static readonly Dictionary<string, GameQueue> k_MultiplayToLocalQueueNames = new Dictionary<string, GameQueue>
        {
            { k_MultiplaySingleplayerQueue, GameQueue.Singleplayer },
            { k_MultiplayCompetetiveQueue, GameQueue.Competitive }
        };

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("GameInfo: ");
        sb.AppendLine($"- gameQueue:  {gameQueue}");
        return sb.ToString();
    }

    /// <summary>
    /// Convert queue enums to ticket queue name
    /// (Same as your queue name in the matchmaker dashboard)
    /// </summary>
    public string ToMultiplayQueue()
    {
        return gameQueue switch
        {
            GameQueue.Singleplayer => k_MultiplaySingleplayerQueue,
            GameQueue.Competitive => k_MultiplayCompetetiveQueue,
            _ => k_MultiplaySingleplayerQueue
        };
    }
}

public class MainMenuController : MenuControllerBase
{
    public CookieRunButton modeSelectButton;
    public CookieRunButton deckEditorButton;
    public CookieRunButton deckSelectButton;

    public CookieRunButton settingsButton;

    public override void Start()
    {
        Debug.Log("MainMenuController::Start");

        base.Start();

        modeSelectButton.OnLeftClick.AddListener(ShowModeOverlay);
        deckEditorButton.OnLeftClick.AddListener(ShowDeckEditorOverlay);
        deckSelectButton.OnLeftClick.AddListener(ShowDeckSelectorOverlay);
        settingsButton.OnLeftClick.AddListener(ShowSettingsOverlay);

        deckSelectButton.interactable = false;

        MenuControllerBase[] allMenus = FindObjectsOfType<MenuControllerBase>();
        foreach (var menu in allMenus)
        {
            menu.HideOverlay();
        }
    }

    public override void HideOverlay()
    {
        Debug.Log("MainMenuController::HideOverlay");
        Debug.Log("The Main Menu overlay does not get hidden");
    }

    void ShowModeOverlay()
    {
        Debug.Log("MainMenuController::ShowModeOverlay");
        //SceneManager.LoadScene("ModeSelectScene", LoadSceneMode.Additive);

        //Temporarily begin playing from here
        if (string.IsNullOrWhiteSpace(ClientStorageManager.Instance.ChosenDeckID))
        {
            Debug.Log("No deck selected");
            return;
        }

        BeginMatchmaking();
    }

    private void BeginMatchmaking()
    {
        Debug.Log("GameModeSelectController::BeginMatchmaking");

        DisplayQueueTimer();

        GameInfo gameInfo = new GameInfo();
        gameInfo.gameQueue = GameQueue.Singleplayer;

        int elo = 1000; //await DatabaseManager.Instance.UserManager.GetPlayerEloAsync(AuthenticationManager.Instance.UserFirebaseID);
        
        string username = AuthenticationService.Instance.PlayerId; //await AuthenticationManager.Instance.GetPlayerNameAsync(true);
        UserData TournamentUserData = new UserData(username, AuthenticationService.Instance.PlayerId, 0, elo, gameInfo);

        ClientStorageManager.Instance.ConnectionDataStorageManager.SaveGameQueue(gameInfo.gameQueue);

        TournamentManager.Instance.JoinTournamentQueue(TournamentUserData);
    }

    public void DisplayQueueTimer()
    {
        Debug.Log("MenuDisplayController::DisplayQueueTimer");
        SceneManager.LoadScene("QueueTimer", LoadSceneMode.Additive);
    }

    public void ShowDeckEditorOverlay()
    {
        Debug.Log("MenuDisplayController::DisplayDeckEditor");
        SceneManager.LoadScene("DeckEditor", LoadSceneMode.Additive);
    }

    public void ShowDeckSelectorOverlay()
    {
        Debug.Log("MenuDisplayController::DisplayDeckSelector");
        SceneManager.LoadScene("DeckSelectorScene", LoadSceneMode.Additive);
    }

    void ShowSettingsOverlay()
    {
        Debug.Log("MainMenuController::ShowSettingsOverlay");
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
    }
}