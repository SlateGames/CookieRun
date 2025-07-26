using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

//Okay, I need to store a DeckMetaData file, and then one file per deck. The key for the metadata file can just be DeckMetaData, and the keys for the decks will be GUIDs

public class DeckDataManager
{
    private readonly string deckFolderPath;
    private const string DECK_FOLDER_NAME = "Decks";

    public DeckDataManager()
    {
        Debug.Log("DeckDataManager::DeckDataManager");
        deckFolderPath = Path.Combine(Application.persistentDataPath, DECK_FOLDER_NAME);
        Directory.CreateDirectory(deckFolderPath);
    }

    private string GetDeckFilePath(string deckId)
    {
        Debug.Log("DeckDataManager::GetDeckFilePath");
        return Path.Combine(deckFolderPath, $"{deckId}.json");
    }

    public Deck GetDeck(string deckId)
    {
        Debug.Log("DeckDataManager::GetDeckFile");

        var deckFilePath = GetDeckFilePath(deckId);
        if (!File.Exists(deckFilePath))
        {
            Debug.LogError($"Deck data file not found for deck {deckId}");
            return new Deck();
        }

        var json = File.ReadAllText(deckFilePath);
        var deck = JsonConvert.DeserializeObject<Deck>(json);

        return deck;
    }

    public bool IsDeckValid(string deckId)
    {
        Debug.Log("DeckDataManager::IsDeckValid");

        Deck deck = GetDeck(deckId);
        if (deck.DeckID != deckId)
        {
            Debug.LogError($"Deck with ID '{deckId}' not found.");
            return false;
        }

        //TODO: Check for Flip count and quantities

        if (deck.Cards.Count != 60)
        {
            Debug.LogError($"Total deck card quantity is {deck.Cards.Count}, which is not equal to 60.");
            return false;
        }

        return true;
    }


    public List<Deck> GetAllDecks()
    {
        Debug.Log("DeckDataManager::GetAllDecks");

        List<Deck> decks = new List<Deck>();

        if (!Directory.Exists(deckFolderPath))
        {
            Debug.LogError($"Deck folder path not found: {deckFolderPath}");
            return decks;
        }

        var deckFiles = Directory.GetFiles(deckFolderPath, "*.json");
        foreach (var file in deckFiles)
        {
            try
            {
                var json = File.ReadAllText(file);
                var deck = JsonConvert.DeserializeObject<Deck>(json);

                decks.Add(deck);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error reading deck file {file}: {ex.Message}");
            }
        }

        return decks;
    }

    public async Task<bool> WriteDeck(Deck deck)
    {
        Debug.Log("DeckDataManager::WriteDeck");

        try
        {
            var json = JsonConvert.SerializeObject(deck, Formatting.Indented);
            File.WriteAllText(GetDeckFilePath(deck.DeckID), json);

            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to write deck {deck.Name}: {ex.Message}");
            return false;
        }
    }

    public async Task DeleteDeck(string deckId)
    {
        Debug.Log("DeckDataManager::DeleteDeck");

        var deckFilePath = GetDeckFilePath(deckId);

        if (!File.Exists(deckFilePath))
        {
            Debug.LogError($"Deck file not found for deck ID {deckId}");
            return;
        }

        Deck deck = GetDeck(deckId);
        try
        {
            File.Delete(deckFilePath);
            Debug.Log($"Successfully deleted deck {deckId}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to delete deck {deckId}: {ex.Message}");
            return;
        }
    }
}