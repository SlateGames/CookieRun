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
        _clientServerBridge.PlayerEnterGamePhase += ClientServerBridge_PlayerEnterGamePhase;
        _clientServerBridge.PlayerExitGamePhase += ClientServerBridge_PlayerExitGamePhase;
    }

    private void ClientServerBridge_PlayerEnterGamePhase(ulong playerId, GamePhase gamePhase)
    {
        Debug.Log("ClientUIController::ClientServerBridge_PlayerEnterGamePhase");
        DebugCurrentPhase.SetText(gamePhase.ToString());

        switch (gamePhase)
        {
            //Setup and Battle have relevant sub-phases, but those will fire their own events for the player to make decisions on
            case GamePhase.Setup:
            case GamePhase.Battle:
            case GamePhase.Active:
            case GamePhase.Draw:
            case GamePhase.End:
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
}
