using System.Threading.Tasks;
using System;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Core.Environments;

public class AuthenticationManager : MonoBehaviour
{
    public static AuthenticationManager Instance { get; private set; }
    
    public event Action OnAuthenticationStarted;
    public event Action<AuthResult> OnAuthenticationCompleted;

    public string UserEmail = "";

    public const string EnvironmentName = "cookie-run";

    private void Awake()
    {
        Debug.Log("AuthenticationManager::Awake");

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.Log("AuthenticationManager::Start");
    }

    private async Task InitializeUnityServicesAsync()
    {
        Debug.Log("AuthenticationManager::InitializeUnityServicesAsync");

        try
        {
            var options = new InitializationOptions().SetEnvironmentName(EnvironmentName);
            await UnityServices.InitializeAsync(options);

            AuthenticationService.Instance.SignedIn += HandleSignedIn;
            AuthenticationService.Instance.SignedOut += HandleSignedOut;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Unity Services initialization failed: {ex.Message}");
            throw;
        }
    }

    public async Task<AuthResult> LoginAnonymouslyAsync()
    {
        Debug.Log("AuthenticationManager::LoginAnonymouslyAsync");

        try
        {
            await InitializeUnityServicesAsync();
            OnAuthenticationStarted?.Invoke();

            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            return new AuthResult { Success = true, UserId = AuthenticationService.Instance.PlayerId };
        }
        catch (Exception ex)
        {
            return HandleAuthError("Anonymous login failed", ex);
        }
    }

    public async Task<AuthResult> LoginWithEmailAsync(string email, string password)
    {
        Debug.Log("AuthenticationManager::LoginWithEmailAsync");

        try
        {
            await InitializeUnityServicesAsync();
            OnAuthenticationStarted?.Invoke();

            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(email, password);
            return new AuthResult { Success = true, UserId = AuthenticationService.Instance.PlayerId };
        }
        catch (AuthenticationException ex)
        {
            Debug.LogException(ex);
            return HandleAuthError("Email login failed", ex);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogException(ex);
            return HandleAuthError("Email login failed", ex);
        }
        catch (Exception ex)
        {
            return HandleAuthError("Email login failed", ex);
        }
    }

    public async Task<AuthResult> RegisterWithEmailAsync(string email, string password)
    {
        Debug.Log("AuthenticationManager::RegisterWithEmailAsync");

        try
        {
            await InitializeUnityServicesAsync();
            OnAuthenticationStarted?.Invoke();

            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(email, password);
            return new AuthResult { Success = true, UserId = AuthenticationService.Instance.PlayerId };
        }
        catch (AuthenticationException ex)
        {
            Debug.LogException(ex);
            return HandleAuthError("Email login failed", ex);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogException(ex);
            return HandleAuthError("Email login failed", ex);
        }
        catch (Exception ex)
        {
            return HandleAuthError("Registration failed", ex);
        }
    }

    public async Task LoginCachedUserAsync()
    {
        Debug.Log("AuthenticationManager::LoginCachedUserAsync");
    }

    private void HandleSignedIn()
    {
        Debug.Log("AuthenticationManager::HandleSignedIn");

        OnAuthenticationCompleted?.Invoke(new AuthResult
        {
            Success = true,
            UserId = AuthenticationService.Instance.PlayerId
        });
    }

    private void HandleSignedOut()
    {
        Debug.Log("AuthenticationManager::HandleSignedOut");
    }

    private AuthResult HandleAuthError(string context, Exception ex)
    {
        Debug.Log("AuthenticationManager::HandleAuthError");

        return new AuthResult
        {
            Success = false,
            ErrorMessage = ex.Message
        };
    }     
}