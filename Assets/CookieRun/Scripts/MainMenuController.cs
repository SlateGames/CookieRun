using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MenuControllerBase
{
    public Button modeSelectButton;
    public Button deckEditorButton;
    public Button deckSelectButton;

    public Button settingsButton;

    public override void Start()
    {
        Debug.Log("MainMenuController::Start");

        base.Start();

        modeSelectButton.onClick.AddListener(ShowModeOverlay);
        deckEditorButton.onClick.AddListener(ShowDeckEditorOverlay);
        deckSelectButton.onClick.AddListener(ShowDeckSelectorOverlay);
        settingsButton.onClick.AddListener(ShowSettingsOverlay);

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
        SceneManager.LoadScene("ModeSelectScene", LoadSceneMode.Additive);
    }

    public void ShowDeckEditorOverlay()
    {
        Debug.Log("MenuDisplayController::DisplayDeckEditor");
        SceneManager.LoadScene("DeckEditScene", LoadSceneMode.Additive);
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