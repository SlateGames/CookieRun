using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerBase : MonoBehaviour
{
    [SerializeField] protected string menuSceneName;

    protected virtual void Awake()
    {
        if (string.IsNullOrEmpty(menuSceneName))
        {
            menuSceneName = gameObject.scene.name;
        }
    }

    public virtual void Start()
    {
        Debug.Log("MenuControllerBase::Start");
    }

    public virtual void HideOverlay()
    {
        Debug.Log("MenuControllerBase::HideOverlay");

        Scene sceneToUnload = SceneManager.GetSceneByName(menuSceneName);
        if (sceneToUnload.IsValid() && sceneToUnload.isLoaded)
        {
            Debug.Log($"Unloading menu scene: {menuSceneName}");
            SceneManager.UnloadSceneAsync(menuSceneName);
        }
        else
        {
            Debug.LogWarning($"Scene '{menuSceneName}' is not loaded or not valid.");
        }
    }
}
