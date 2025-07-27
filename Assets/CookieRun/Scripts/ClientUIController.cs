using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO: This should really be a state machine
//TODO: Actually, this should not be a state machine, but we should have more than one class that subs to the events in CSB
public class ClientUIController : MonoBehaviour
{
    private ulong _ownerClientId;
    //TODO: Remove this var
    private ClientServerBridge _clientServerBridge;

    public TMP_Text DebugCurrentPhase;
    public TMP_Text DebugPreviousPhase;
    public Button DebugPassPriority;

    [SerializeField] private Button _buttonSkipSupport;
    [SerializeField] private Button _buttonEndTurn;

    [SerializeField] private TMP_Text _playerDeckCount;
    [SerializeField] private TMP_Text _opponentDeckCount;

    [SerializeField] private UIController_Break _playerBreakController;
    [SerializeField] private UIController_Stage _playerStageController;
    [SerializeField] private UIController_Battle _playerBattleController;
    [SerializeField] private UIController_Deck _playerDeckController;
    [SerializeField] private UIController_Support _playerSupportController;
    [SerializeField] private UIController_Trash _playerTrashController;
    [SerializeField] private UIController_Hand _playerHandController;

    [SerializeField] private UIController_Break _opponentBreakController;
    [SerializeField] private UIController_Stage _opponentStageController;
    [SerializeField] private UIController_Battle _opponentBattleController;
    [SerializeField] private UIController_Deck _opponentDeckController;
    [SerializeField] private UIController_Support _opponentSupportController;
    [SerializeField] private UIController_Trash _opponentTrashController;
    [SerializeField] private UIController_Hand _opponentHandController;

    public void Initialize(ulong ownerId, ClientServerBridge clientServerBridge)
    {
        Debug.Log("ClientUIController::Initialize");

        _ownerClientId = ownerId;
        _clientServerBridge = clientServerBridge;

        SubscribeToClientServerBridgeEvents();

        _buttonSkipSupport.gameObject.SetActive(false);
        _buttonEndTurn.gameObject.SetActive(false);

        DebugPassPriority.onClick.AddListener(PassPriority);
        _buttonSkipSupport.onClick.AddListener(SkipSupport);
        _buttonEndTurn.onClick.AddListener(EndTurn);
    }

    private void SubscribeToClientServerBridgeEvents()
    {
        Debug.Log("ClientUIController::SubscribeToClientServerBridgeEvents");

        _clientServerBridge.TestAction += ClientServerBridge_TestAction;
        _clientServerBridge.DeckRegisteredForPlayer += ClientServerBridge_DeckRegisteredForPlayer;
        _clientServerBridge.DeckShuffled += ClientServerBridge_DeckShuffled;
        _clientServerBridge.CardChangeZone += ClientServerBridge_CardChangeZone;
        _clientServerBridge.MulligansStart += ClientServerBridge_MulligansStart;
        _clientServerBridge.MulligansEnd += ClientServerBridge_MulligansEnd;
        _clientServerBridge.GameStart += ClientServerBridge_GameStart;
        _clientServerBridge.NewActivePlayer += ClientServerBridge_NewActivePlayer;
        _clientServerBridge.PlayerEnterGamePhase += ClientServerBridge_PlayerEnterGamePhase;
        _clientServerBridge.PlayerExitGamePhase += ClientServerBridge_PlayerExitGamePhase;
    }

    private void ClientServerBridge_DeckRegisteredForPlayer(DeckDataPayload deckData)
    {
        Debug.Log("ClientUIController::ClientServerBridge_DeckRegisteredForPlayer");

        if(deckData.PlayerId == _ownerClientId)
        {
            _playerDeckCount.SetText(deckData.Deck.Cards.Count.ToString());
        }
        else
        {
            _opponentDeckCount.SetText(deckData.Deck.Cards.Count.ToString());
        }
    }

    private void ClientServerBridge_DeckShuffled(ulong deckId)
    {
        Debug.Log("ClientUIController::ClientServerBridge_DeckShuffled");
    }

    private void ClientServerBridge_CardChangeZone(ulong playerId, string cardId, int cardMatchId, GameZoneType sourceZone, GameZoneType destinationZone)
    {
        Debug.Log("ClientUIController::ClientServerBridge_CardChangeZone");

        UIController_Base sourceController = GetControllerByZone(sourceZone, playerId == _ownerClientId);
        if (sourceController != null)
        {
            sourceController.RemoveCard(cardMatchId);
        }

        GameObject cardInstance = ClientCardManager.Instance.GetCardInstance(cardId);
        if (cardInstance != null)
        {
            CardController cardController = cardInstance.GetComponent<CardController>();
            if (cardController != null)
            {
                cardController.UpdateCardMatchId(cardMatchId);
            }

            UIController_Base destinationController = GetControllerByZone(destinationZone, playerId == _ownerClientId);
            if (destinationController != null)
            {
                destinationController.AddCard(cardInstance);
            }
        }
    }


    private void ClientServerBridge_MulligansStart()
    {
        Debug.Log("ClientUIController::ClientServerBridge_MulligansStart");
    }

    private void ClientServerBridge_MulligansEnd()
    {
        Debug.Log("ClientUIController::ClientServerBridge_MulligansEnd");
    }

    private void ClientServerBridge_GameStart()
    {
        Debug.Log("ClientUIController::ClientServerBridge_GameStart");
    }

    private void ClientServerBridge_NewActivePlayer(ulong playerId)
    {
        Debug.Log("ClientUIController::ClientServerBridge_NewActivePlayer");
        DebugPassPriority.interactable = playerId == _ownerClientId;
    }

    private void ClientServerBridge_PlayerEnterGamePhase(ulong playerId, GamePhase gamePhase)
    {
        Debug.Log("ClientUIController::ClientServerBridge_PlayerEnterGamePhase");
        DebugCurrentPhase.SetText(gamePhase.ToString());

        switch (gamePhase)
        {
            //Setup and Battle have relevant sub-phases, but those will fire their own events for the player to make decisions on
            case GamePhase.Battle:
            case GamePhase.Active:
            case GamePhase.Draw:
            case GamePhase.End:
                break;
            case GamePhase.Setup:
                Deck deck = ClientStorageManager.Instance.DeckDataManager.GetDeck(ClientStorageManager.Instance.ChosenDeckID);
                _clientServerBridge.RegisterPlayerServerRpc(_ownerClientId, deck);
                break;
            case GamePhase.Support:
                if (playerId == _ownerClientId)
                {
                    _buttonSkipSupport.gameObject.SetActive(true);
                }
                else
                {
                    _buttonSkipSupport.gameObject.SetActive(false);                    
                }
                break;
            case GamePhase.Main:
                if (playerId == _ownerClientId)
                {
                    _buttonEndTurn.gameObject.SetActive(true);
                }
                else
                {
                    _buttonEndTurn.gameObject.SetActive(false);
                }
                break;
            default:
                throw new InvalidOperationException($"Unknown GamePhase: {gamePhase}");
        }
    }

    private void ClientServerBridge_PlayerExitGamePhase(ulong playerId, GamePhase gamePhase)
    {
        Debug.Log("ClientUIController::ClientServerBridge_PlayerExitGamePhase");
        DebugPreviousPhase.SetText(gamePhase.ToString());
    }

    private void ClientServerBridge_TestAction()
    {
        Debug.Log("Test Action triggered Client UI Controller function!");
    }

    private void PassPriority()
    {
        Debug.Log("ClientUIController::PassPriority");
        _clientServerBridge.PassPriorityServerRpc(_ownerClientId);
    }

    private void SkipSupport()
    {
        Debug.Log("ClientUIController::SkipSupport");
        _clientServerBridge.SkipSupportServerRpc(_ownerClientId);
    }

    private void EndTurn()
    {
        Debug.Log("ClientUIController::EndTurn");
        _clientServerBridge.EndTurnServerRpc(_ownerClientId);
    }

    private UIController_Base GetControllerByZone(GameZoneType zoneType, bool isPlayer)
    {
        if (isPlayer)
        {
            switch (zoneType)
            {
                case GameZoneType.Break:
                    return _playerBreakController;
                case GameZoneType.Stage:
                    return _playerStageController;
                case GameZoneType.Battle:
                    return _playerBattleController;
                case GameZoneType.Deck:
                    return _playerDeckController;
                case GameZoneType.Support:
                    return _playerSupportController;
                case GameZoneType.Trash:
                    return _playerTrashController;
                case GameZoneType.Hand:
                    return _playerHandController;
                default:
                    return null;
            }
        }
        else
        {
            switch (zoneType)
            {
                case GameZoneType.Break:
                    return _opponentBreakController;
                case GameZoneType.Stage:
                    return _opponentStageController;
                case GameZoneType.Battle:
                    return _opponentBattleController;
                case GameZoneType.Deck:
                    return _opponentDeckController;
                case GameZoneType.Support:
                    return _opponentSupportController;
                case GameZoneType.Trash:
                    return _opponentTrashController;
                case GameZoneType.Hand:
                    return _opponentHandController;
                default:
                    return null;
            }
        }
    }
}
