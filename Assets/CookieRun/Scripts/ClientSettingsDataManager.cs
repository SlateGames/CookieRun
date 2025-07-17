using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class ClientSettingsDataManager
{
    private readonly string SETTINGS_DIRECTORY;
    private readonly string SETTINGS_FILE_PATH;

    private ClientSettings _settings;

    [Serializable]
    private class ClientSettings
    {
        public bool AutoSignIn = true;
        public bool HasAgreedToEULA = false;

        public int MusicLevel = 80;
        public int SFXLevel = 80;
        public int UILevel = 80;
        public int CardLevel = 80;

        public int ScrollIntensity = 50;

        public int SchemaVersion = 1;
    }

    public ClientSettingsDataManager()
    {
        SETTINGS_DIRECTORY = Path.Combine(Application.persistentDataPath, "Settings");
        SETTINGS_FILE_PATH = Path.Combine(SETTINGS_DIRECTORY, "ChronoClientSettings.dat");

        LoadSettings();
    }

    private void LoadSettings()
    {
        _settings = new ClientSettings();

        if (File.Exists(SETTINGS_FILE_PATH) == false)
        {
            SaveSettings();
            return;
        }

        string json = File.ReadAllText(SETTINGS_FILE_PATH);

        var settings = SafeDeserialize(json);
        if (settings != null)
        {
            _settings = settings;
        }
    }

    private ClientSettings SafeDeserialize(string json)
    {
        try
        {
            // First, try normal deserialization
            var settings = JsonConvert.DeserializeObject<ClientSettings>(json, new JsonSerializerSettings
            {
                Error = (sender, args) =>
                {
                    // Log the error but continue
                    Debug.LogWarning($"ClientSettingsDataManager::SafeDeserialize | Error deserializing setting: {args.ErrorContext.Error.Message}");
                    args.ErrorContext.Handled = true;
                },
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            return settings;
        }
        catch (JsonException ex)
        {
            Debug.LogError($"ClientSettingsDataManager::SafeDeserialize | Error during deserialization, attempting manual recovery: {ex.Message}");
            return null;
        }
    }

    private void SaveSettings()
    {
        try
        {
            if (!Directory.Exists(SETTINGS_DIRECTORY))
            {
                Directory.CreateDirectory(SETTINGS_DIRECTORY);
            }

            string json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText(SETTINGS_FILE_PATH, json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"ClientSettingsDataManager::SaveSettings | Failed to save settings: {ex.Message}");
        }
    }

    public bool GetAutoLogIn()
    {
        Debug.Log("ClientSettingsDataManager::GetAutoLogIn");
        return _settings.AutoSignIn;
    }

    public void SetAutoLogIn(bool autoLogin)
    {
        Debug.Log($"ClientSettingsDataManager::SetAutoLogIn");

        _settings.AutoSignIn = autoLogin;

        SaveSettings();
    }

    public bool GetHasAgreedToEULA()
    {
        Debug.Log("ClientSettingsDataManager::GetHasAgreedToEULA");
        return _settings.HasAgreedToEULA;
    }

    public void SetHasAgreedToEULA(bool hasAgreedToEULA)
    {
        Debug.Log($"ClientSettingsDataManager::SetHasAgreedToEULA");

        _settings.HasAgreedToEULA = hasAgreedToEULA;
        SaveSettings();
    }

    public void SetMusicLevel(int newLevel)
    {
        Debug.Log($"ClientSettingsDataManager::SetMusicLevel");

        _settings.MusicLevel = newLevel;
        SaveSettings();
    }

    public int GetMusicVolumeLevel()
    {
        Debug.Log($"ClientSettingsDataManager::GetMusicVolumeLevel");
        return _settings.MusicLevel;
    }

    public void SetSFXLevel(int newLevel)
    {
        Debug.Log($"ClientSettingsDataManager::SetSFXLevel");

        _settings.SFXLevel = newLevel;
        SaveSettings();
    }

    public int GetSFXVolumeLevel()
    {
        Debug.Log($"ClientSettingsDataManager::GetSFXVolumeLevel");
        return _settings.SFXLevel;
    }

    public void SetUILevel(int newLevel)
    {
        Debug.Log($"ClientSettingsDataManager::SetUILevel");

        _settings.UILevel = newLevel;
        SaveSettings();
    }

    public int GetUIVolumeLevel()
    {
        Debug.Log($"ClientSettingsDataManager::GetUIVolumeLevel");
        return _settings.UILevel;
    }

    public void SetCardLevel(int newLevel)
    {
        Debug.Log($"ClientSettingsDataManager::SetCardLevel");

        _settings.CardLevel = newLevel;
        SaveSettings();
    }

    public int GetCardVolumeLevel()
    {
        Debug.Log($"ClientSettingsDataManager::GetCardVolumeLevel");
        return _settings.CardLevel;
    }
}