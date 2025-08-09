using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System.Reflection;
using System;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;

public class DeckEditorController : MenuControllerBase
{
    [Header("Deck Editor Settings")]
    [SerializeField] private GameObject[] deckEditorCardSlots = new GameObject[18]; // Array of 18 card slot GameObjects
    [SerializeField] private CookieRunButton nextPageButton;
    [SerializeField] private CookieRunButton previousPageButton;
    [SerializeField] private CookieRunButton saveButton;
    [SerializeField] private CookieRunButton cancelButton;
    [SerializeField] private CookieRunButton newDeckButton;
    [SerializeField] private TMP_Dropdown deckSelectDropdown;
    
    public TMP_InputField deckName;
    public TMP_InputField cardFilterInput;

    private List<Card_Base> allCards = new List<Card_Base>();
    private int currentPage = 0;
    private const int CARDS_PER_PAGE = 18;
    private List<Deck> _decks = new List<Deck>();

    private Deck currentDeck = new Deck();

    void Start()
    {
        LoadDeck(ClientStorageManager.Instance.ChosenDeckID);

        LoadAllCards();
        SetupButtons();
        SetupCardSlotButtons();
        DisplayCurrentPage();
        SetupDeckDropdown();        
    }

    public override void HideOverlay()
    {
        ClientStorageManager.Instance.ChosenDeckID = currentDeck.DeckID;
        base.HideOverlay();
    }

    private void SetupDeckDropdown()
    {
        Debug.Log("DeckEditorController::SetupDeckDropdown");

        deckSelectDropdown.ClearOptions();

        _decks = ClientStorageManager.Instance.DeckDataManager.GetAllDecks();
        List<string> deckNames = new List<string>();
        foreach (Deck deck in _decks)
        {
            deckNames.Add(deck.Name);
        }

        deckSelectDropdown.AddOptions(deckNames);
        deckSelectDropdown.onValueChanged.RemoveAllListeners();
        deckSelectDropdown.onValueChanged.AddListener(OnDeckSelected);

        if (_decks.Count > 0)
        {
            deckSelectDropdown.value = 0;
            deckSelectDropdown.RefreshShownValue();
            LoadDeck(_decks[0].DeckID);
        }
    }

    private void OnDeckSelected(int index)
    {
        if (index >= 0 && index < _decks.Count)
        {
            string selectedDeckID = _decks[index].DeckID;
            LoadDeck(selectedDeckID);
        }
    }


    public void LoadDeck(string deckId)
    {
        Debug.Log("DeckEditorController::LoadDeck");
        
        if (string.IsNullOrWhiteSpace(deckId))
        {
            currentDeck = new Deck("New Deck");
            currentDeck.DeckID = Guid.NewGuid().ToString();
            currentDeck.Cards = new List<DeckCard>();

            if(UnityServices.State == ServicesInitializationState.Initialized)
            {
                currentDeck.UserID = AuthenticationService.Instance?.PlayerId;
            }

            currentDeck.Name = "NEW DECK";
            deckName.text = currentDeck.Name;

            return;
        }

        currentDeck = ClientStorageManager.Instance.DeckDataManager.GetDeck(deckId);
        deckName.text = currentDeck.Name;

        DisplayCurrentPage();
    }


    private void SetupButtons()
    {
        if (nextPageButton != null)
        {
            nextPageButton.OnLeftClick.AddListener(NextPage);
        }

        if (previousPageButton != null)
        {
            previousPageButton.OnLeftClick.AddListener(PreviousPage);
        }

        if (saveButton != null)
        {
            saveButton.OnLeftClick.AddListener(OnSaveClicked);
        }

        if (cancelButton != null)
        {
            cancelButton.OnLeftClick.AddListener(OnCancelClicked);
        }

        if (newDeckButton != null)
        {
            newDeckButton.OnLeftClick.AddListener(OnNewDeckClicked);
        }
    }

    private void SetupCardSlotButtons()
    {
        for (int slotIndex = 0; slotIndex < deckEditorCardSlots.Length; slotIndex++)
        {
            if (deckEditorCardSlots[slotIndex] != null)
            {
                SetupButtonsForSlot(slotIndex);
                SetupCardButtonEvents(slotIndex);
            }
        }
    }

    private void SetupButtonsForSlot(int slotIndex)
    {
        GameObject slot = deckEditorCardSlots[slotIndex];

        for (int buttonIndex = 0; buttonIndex < 5; buttonIndex++)
        {
            string buttonName = $"Button_{buttonIndex:00}";
            CookieRunButton button = FindButtonInSlot(slot, buttonName);

            if (button != null)
            {
                // Capture the variables in the closure
                int capturedSlotIndex = slotIndex;
                int capturedButtonIndex = buttonIndex;

                button.OnLeftClick.AddListener(() => OnCardSlotButtonClicked(capturedSlotIndex, capturedButtonIndex));
            }
            else
            {
                Debug.LogWarning($"Button {buttonName} not found in slot {slotIndex}");
            }
        }
    }

    private CookieRunButton FindButtonInSlot(GameObject slot, string buttonName)
    {
        // Search for the button by name in the slot and its children
        Transform buttonTransform = slot.transform.Find(buttonName);
        if (buttonTransform != null)
        {
            return buttonTransform.GetComponent<CookieRunButton>();
        }

        // If not found directly, search recursively in children
        CookieRunButton[] buttons = slot.GetComponentsInChildren<CookieRunButton>();
        foreach (CookieRunButton button in buttons)
        {
            if (button.name == buttonName)
            {
                return button;
            }
        }

        return null;
    }

    private void SetupCardButtonEvents(int slotIndex)
    {
        GameObject slot = deckEditorCardSlots[slotIndex];

        // Find CardButton in the CardVisual child
        Transform cardVisual = slot.transform.Find("CardVisual");
        if (cardVisual != null)
        {
            Transform cardButtonTransform = cardVisual.Find("CardButton");
            if (cardButtonTransform != null)
            {
                CookieRunButton cardButton = cardButtonTransform.GetComponent<CookieRunButton>();
                if (cardButton != null)
                {
                    // Capture slot index for closures
                    int capturedSlotIndex = slotIndex;

                    // Use CookieRunButton's built-in events
                    cardButton.OnHoverEnter.AddListener(() => OnCardButtonHoverEnter(capturedSlotIndex));
                    cardButton.OnHoverExit.AddListener(() => OnCardButtonHoverExit(capturedSlotIndex));
                    cardButton.OnLeftClick.AddListener(() => OnCardButtonLeftClick(capturedSlotIndex));
                    cardButton.OnRightClick.AddListener(() => OnCardButtonRightClick(capturedSlotIndex));

                    // If you need left click or double click
                    // cardButton.OnLeftClick.AddListener(() => OnCardButtonLeftClick(capturedSlotIndex));
                    // cardButton.OnDoubleClick.AddListener(() => OnCardButtonDoubleClick(capturedSlotIndex));
                }
                else
                {
                    Debug.LogWarning($"CookieRunButton component not found on CardButton in slot {slotIndex}");
                }
            }
            else
            {
                Debug.LogWarning($"CardButton not found in CardVisual for slot {slotIndex}");
            }
        }
        else
        {
            Debug.LogWarning($"CardVisual not found in slot {slotIndex}");
        }
    }

    private void OnCardSlotButtonClicked(int slotIndex, int buttonIndex)
    {
        // Calculate the actual card index based on current page and slot
        int cardIndex = (currentPage * CARDS_PER_PAGE) + slotIndex;

        // Make sure we have a valid card for this slot
        if (cardIndex >= 0 && cardIndex < allCards.Count)
        {
            Card_Base card = allCards[cardIndex];

            switch (buttonIndex)
            {
                case 0:
                    OnButton00Clicked(slotIndex, card);
                    break;
                case 1:
                    OnButton01Clicked(slotIndex, card);
                    break;
                case 2:
                    OnButton02Clicked(slotIndex, card);
                    break;
                case 3:
                    OnButton03Clicked(slotIndex, card);
                    break;
                case 4:
                    OnButton04Clicked(slotIndex, card);
                    break;
            }
        }
    }

    private void OnCardButtonLeftClick(int slotIndex)
    {
        Debug.Log($"Left clicked on card in slot {slotIndex}");
    }

    private void OnCardButtonRightClick(int slotIndex)
    {
        Debug.Log($"Right clicked on card in slot {slotIndex}");
    }

    private void OnCardButtonHoverEnter(int slotIndex)
    {
        // Calculate the actual card index based on current page and slot
        int cardIndex = (currentPage * CARDS_PER_PAGE) + slotIndex;

        // Make sure we have a valid card for this slot
        if (cardIndex >= 0 && cardIndex < allCards.Count)
        {
            GameObject slot = deckEditorCardSlots[slotIndex];
            Transform cardVisual = slot.transform.Find("CardVisual");
            if (cardVisual != null)
            {
                Transform cardImage = cardVisual.Find("CardImage");
                if (cardImage != null)
                {
                    // Scale up the card image for zoom effect
                    cardImage.localScale = Vector3.one * 4.0f;
                    slot.transform.SetAsLastSibling();
                    cardVisual.SetAsLastSibling();
                }
            }
        }
    }

    private void OnCardButtonHoverExit(int slotIndex)
    {
        GameObject slot = deckEditorCardSlots[slotIndex];
        Transform cardVisual = slot.transform.Find("CardVisual");
        if (cardVisual != null)
        {
            Transform cardImage = cardVisual.Find("CardImage");
            if (cardImage != null)
            {
                // Reset the card image scale
                cardImage.localScale = Vector3.one;
            }
        }
    }

    private void OnButton00Clicked(int slotIndex, Card_Base card)
    {
        // Button 00 = Set quantity to 0 (remove card)
        SetCardQuantityInDeck(card.CardId, 0);
        UpdateButtonColorsForSlot(slotIndex, 0);
        Debug.Log($"Button 00 clicked for slot {slotIndex}, card ID: {card.CardId}, card Name: {card.CardName} - Removed from deck");
    }

    private void OnButton01Clicked(int slotIndex, Card_Base card)
    {
        // Button 01 = Set quantity to 1
        SetCardQuantityInDeck(card.CardId, 1);
        UpdateButtonColorsForSlot(slotIndex, 1);
        Debug.Log($"Button 01 clicked for slot {slotIndex}, card ID: {card.CardId}, card Name: {card.CardName} - Set to 1");
    }

    private void OnButton02Clicked(int slotIndex, Card_Base card)
    {
        // Button 02 = Set quantity to 2
        SetCardQuantityInDeck(card.CardId, 2);
        UpdateButtonColorsForSlot(slotIndex, 2);
        Debug.Log($"Button 02 clicked for slot {slotIndex}, card ID: {card.CardId}, card Name: {card.CardName} - Set to 2");
    }

    private void OnButton03Clicked(int slotIndex, Card_Base card)
    {
        // Button 03 = Set quantity to 3
        SetCardQuantityInDeck(card.CardId, 3);
        UpdateButtonColorsForSlot(slotIndex, 3);
        Debug.Log($"Button 03 clicked for slot {slotIndex}, card ID: {card.CardId}, card Name: {card.CardName} - Set to 3");
    }

    private void OnButton04Clicked(int slotIndex, Card_Base card)
    {
        // Button 04 = Set quantity to 4
        SetCardQuantityInDeck(card.CardId, 4);
        UpdateButtonColorsForSlot(slotIndex, 4);
        Debug.Log($"Button 04 clicked for slot {slotIndex}, card ID: {card.CardId}, card Name: {card.CardName} - Set to 4");
    }

    private void UpdateButtonColorsForSlot(int slotIndex, int currentQuantity)
    {
        GameObject slot = deckEditorCardSlots[slotIndex];

        for (int buttonIndex = 0; buttonIndex < 5; buttonIndex++)
        {
            string buttonName = $"Button_{buttonIndex:00}";
            CookieRunButton button = FindButtonInSlot(slot, buttonName);

            if (button != null)
            {
                Color targetColor;

                if (buttonIndex == 0)
                {
                    targetColor = Color.red;
                }
                else if (buttonIndex <= currentQuantity)
                {
                    targetColor = Color.green;
                }
                else
                {
                    targetColor = Color.white;
                }

                Image buttonImage = button.GetComponent<Image>();
                if (buttonImage != null)
                {
                    buttonImage.color = targetColor;
                }
            }
        }
    }

    private void SetCardQuantityInDeck(string cardId, int quantity)
    {
        int existingCardIndex = currentDeck.Cards.FindIndex(dc => dc.CardID == cardId);

        if (quantity == 0)
        {
            if (existingCardIndex >= 0)
            {
                currentDeck.Cards.RemoveAt(existingCardIndex);
            }
        }
        else
        {
            if (existingCardIndex < 0)
            {
                currentDeck.Cards.Add(new DeckCard { CardID = cardId, Quantity = 0 });
                existingCardIndex = currentDeck.Cards.FindIndex(dc => dc.CardID == cardId);
            }

            DeckCard updatedCard = currentDeck.Cards[existingCardIndex];
            updatedCard.Quantity = quantity;
            updatedCard.DeckID = currentDeck.DeckID;
            currentDeck.Cards[existingCardIndex] = updatedCard;
        }
    }

    private void LoadAllCards()
    {
        List<Type> cardTypes = GetAllCardTypes();

        foreach (Type cardType in cardTypes)
        {
            Card_Base cardInstance = (Card_Base)Activator.CreateInstance(cardType);
            if (cardInstance == null || cardInstance.CardTexture == null)
            {
                continue;
            }

            allCards.Add(cardInstance);
        }

        Debug.Log($"Loaded {allCards.Count} cards into deck editor");
    }

    private void DisplayCurrentPage()
    {
        // Clear all card slots first
        for (int i = 0; i < deckEditorCardSlots.Length; i++)
        {
            if (deckEditorCardSlots[i] != null)
            {
                CardVisualController visualController = deckEditorCardSlots[i].GetComponentInChildren<CardVisualController>();
                if (visualController != null)
                {
                    visualController.ClearCard(); // You might need to implement this method
                }

                // Hide the card slot if no card to display
                deckEditorCardSlots[i].SetActive(false);
            }
        }

        // Calculate which cards to display
        int startIndex = currentPage * CARDS_PER_PAGE;
        int endIndex = Mathf.Min(startIndex + CARDS_PER_PAGE, allCards.Count);

        // Display cards for current page
        for (int i = startIndex; i < endIndex; i++)
        {
            int slotIndex = i - startIndex;
            if (slotIndex < deckEditorCardSlots.Length && deckEditorCardSlots[slotIndex] != null)
            {
                deckEditorCardSlots[slotIndex].SetActive(true);

                CardVisualController visualController = deckEditorCardSlots[slotIndex].GetComponentInChildren<CardVisualController>();
                if (visualController != null)
                {
                    visualController.LoadImage(allCards[i].CardTexture);
                }
                else
                {
                    Debug.LogWarning($"CardVisualController not found on card slot {slotIndex} for card ID: {allCards[i].CardId}");
                }

                // Find the quantity of this card in the current deck
                int cardQuantity = 0;
                DeckCard deckCard = currentDeck.Cards.Find(dc => dc.CardID == allCards[i].CardId);
                cardQuantity = deckCard.Quantity;

                // Call the button click handler with the slot index and card quantity
                OnCardSlotButtonClicked(slotIndex, cardQuantity);
            }
        }

        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        int totalPages = Mathf.CeilToInt((float)allCards.Count / CARDS_PER_PAGE);

        if (previousPageButton != null)
        {
            previousPageButton.interactable = currentPage > 0;
        }

        if (nextPageButton != null)
        {
            nextPageButton.interactable = currentPage < totalPages - 1;
        }
    }

    private void NextPage()
    {
        int totalPages = Mathf.CeilToInt((float)allCards.Count / CARDS_PER_PAGE);
        if (currentPage < totalPages - 1)
        {
            currentPage++;
            DisplayCurrentPage();
        }
    }

    private void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            DisplayCurrentPage();
        }
    }

    private void OnSaveClicked()
    {
        currentDeck.Name = deckName.text;
        ClientStorageManager.Instance.DeckDataManager.WriteDeck(currentDeck);

        HideOverlay();
    }

    private void OnCancelClicked()
    {
        currentDeck = new Deck();
        HideOverlay();
    }

    private void OnNewDeckClicked()
    {
        LoadDeck("");
    }

    private List<Type> GetAllCardTypes()
    {
        List<Type> cardTypes = new List<Type>();
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (Assembly assembly in assemblies)
        {
            try
            {
                List<Type> types = assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(Card_Base)) && !t.IsAbstract)
                    .ToList();

                cardTypes.AddRange(types);
            }
            catch (ReflectionTypeLoadException ex)
            {
                Debug.LogWarning($"Could not load some types from assembly {assembly.FullName}: {ex.Message}");
            }
        }

        return cardTypes;
    }
}