using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Services.Authentication;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthResult
{
    public bool Success;
    public string UserId;
    public string ErrorMessage;
}

public class LoginUIController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private CookieRunButton anonLoginButton;
    [SerializeField] private CookieRunButton emailLoginButton;
    [SerializeField] private CookieRunButton recoveryAccountButton;
    [SerializeField] private CookieRunButton createAccountButton;
    [SerializeField] private CookieRunButton quitButton;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private Toggle AutoSignInToggle;
    [SerializeField] private Toggle toggleVisibilityPasswordButton;
    [SerializeField] private Sprite showPasswordIcon;
    [SerializeField] private Sprite hidePasswordIcon;

    private void Start()
    {
        Debug.Log("LoginUIController::Start");

        InitializeUI();
        SubscribeToEvents();

        if(ClientStorageManager.Instance.ClientSettingsDataManager.GetHasAgreedToEULA() == false)
        {
            SceneManager.LoadScene("EULAScene", LoadSceneMode.Additive);
            return;
        }
        if(ClientStorageManager.Instance.ClientSettingsDataManager.GetAutoLogIn())
        {
            SignInCachedUserAsync();
        }
    }

    private void InitializeUI()
    {
        Debug.Log("LoginUIController::InitializeUI");

        if (ValidateReferences() == false)
        {
            return;
        }

        anonLoginButton.OnLeftClick.AddListener(OnAnonymousLoginClicked);
        emailLoginButton.OnLeftClick.AddListener(OnEmailLoginClicked);
        quitButton.OnLeftClick.AddListener(OnQuitClicked);
        createAccountButton.OnLeftClick.AddListener(OnEmailRegistrationClicked);
        recoveryAccountButton.OnLeftClick.AddListener(OnRecoveryAccountClicked);
        toggleVisibilityPasswordButton.onValueChanged.AddListener(OnPasswordVisibilityToggleChanged);
        quitButton.gameObject.SetActive(false);
        AutoSignInToggle.onValueChanged.AddListener(OnAutoSignInToggleValueChanged);
        AutoSignInToggle.isOn = ClientStorageManager.Instance.ClientSettingsDataManager.GetAutoLogIn();
    }

    void OnPasswordVisibilityToggleChanged(bool isOn)
    {
        passwordInputField.contentType = isOn ?
            TMP_InputField.ContentType.Standard :
            TMP_InputField.ContentType.Password;

        passwordInputField.ForceLabelUpdate();
        UpdateIcon(isOn);
    }

    void UpdateIcon(bool displayingText)
    {
        if (toggleVisibilityPasswordButton.image != null)
        {
            toggleVisibilityPasswordButton.image.sprite = displayingText ? hidePasswordIcon : showPasswordIcon;
        }
    }

    private bool ValidateReferences()
    {
        Debug.Log("LoginUIController::ValidateReferences");

        if (AuthenticationManager.Instance == null)
        {
            Debug.LogError("Authentication Manager not found");
            return false;
        }

        if (emailLoginButton == null || emailInputField == null || passwordInputField == null)
        {
            Debug.LogError("Missing UI references in LoginUIController");
            return false;
        }

        return true;
    }

    private void SubscribeToEvents()
    {
        Debug.Log("LoginUIController::SubscribeToEvents");

        AuthenticationManager.Instance.OnAuthenticationStarted += OnAuthenticationStarted;
        AuthenticationManager.Instance.OnAuthenticationCompleted += OnAuthenticationCompleted;
    }

    private void OnAutoSignInToggleValueChanged(bool isOn)
    {
        Debug.Log("LoginUIController::OnAutoSignInToggleValueChanged");
        ClientStorageManager.Instance.ClientSettingsDataManager.SetAutoLogIn(isOn);
    }

    private async void OnAnonymousLoginClicked()
    {
        Debug.Log("LoginUIController::OnAnonymousLoginClicked");

        try
        {
            var authResult = await AuthenticationManager.Instance.LoginAnonymouslyAsync();
            Debug.Log("Auth Result User ID: " + authResult.UserId);
            Debug.Log("Auth Manager User ID: " + AuthenticationService.Instance.PlayerId);

            if (authResult.Success)
            {
                //int userId = await DatabaseManager.Instance.UserManager.UpsertUserAsync(authResult.UserId, authResult.UserId + "@noemail.com", "anonloginnopasswordhash", authResult.UserId);
                //Debug.Log($"Created User: {userId}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Anonymous login error: {ex.Message}");
        }
    }

    private async void SignInCachedUserAsync()
    {
        await AuthenticationManager.Instance.LoginCachedUserAsync();
    }

    private async void OnEmailLoginClicked()
    {
        Debug.Log("LoginUIController::OnEmailLoginClicked");
                 
        try
        {

        }
        catch (Exception ex)
        {
            Debug.LogError($"Email login error: {ex.Message}");
            ShowError("An error occurred during email login. Please check your credentials and try again.");
            emailLoginButton.interactable = true;
        }
    }

    private void OnEmailRegistrationClicked()
    {
        Debug.Log("LoginUIController::OnEmailRegistrationClicked");

        try
        {            
           
        }
        catch (Exception ex)
        {
            Debug.LogError($"Email registration error: {ex.Message}");
            ShowError("An error occurred during email registration. Please check your credentials and try again.");
        }
    }

    private void OnRecoveryAccountClicked()
    {
        Debug.Log("LoginUIController::OnRecoveryAccountClicked");

        try
        {            

        }
        catch (Exception ex)
        {
            Debug.LogError($"Email registration error: {ex.Message}");
            ShowError("An error occurred during email registration. Please check your credentials and try again.");
        }
    }

    private void OnQuitClicked()
    {
        Debug.Log("LoginUIController::OnQuitClicked");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnAuthenticationStarted()
    {
        Debug.Log("LoginUIController::OnAuthenticationStarted");
        emailLoginButton.interactable = false;
    }

    private void OnAuthenticationCompleted(AuthResult result)
    {
        Debug.Log("LoginUIController::OnAuthenticationCompleted");

        if (result.Success)
        {
            Debug.Log($"Successfully authenticated. User ID: {result.UserId}");
            SceneManager.LoadSceneAsync("MainMenu");
        }
        else
        {
            Debug.LogError($"Authentication failed: {result.ErrorMessage}");
            ShowError("Login failed. Please try again.");
            emailLoginButton.interactable = true;
        }
    }
  
    private void ShowError(string message)
    {
        Debug.Log("LoginUIController::ShowError");
        emailLoginButton.interactable = true;
    }

    private void OnDestroy()
    {
        Debug.Log("LoginUIController::OnDestroy");

        if (AuthenticationManager.Instance != null)
        {
            AuthenticationManager.Instance.OnAuthenticationStarted -= OnAuthenticationStarted;
            AuthenticationManager.Instance.OnAuthenticationCompleted -= OnAuthenticationCompleted;
        }

        if (emailLoginButton != null)
        {
            emailLoginButton.onClick.RemoveListener(OnEmailLoginClicked);
        }
    }
}