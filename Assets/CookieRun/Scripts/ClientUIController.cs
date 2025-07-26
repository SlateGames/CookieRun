using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO: This should really be a state machine
//TODO: Actually, this should not be a state machine, but we should have more than one class that subs to the events in CSB
public class ClientUIController : MonoBehaviour
{
    //TODO: Make private
    public ulong _ownerClientId;
    //TODO: Remove this var
    private ClientServerBridge _clientServerBridge;

    public TMP_Text DebugCurrentPhase;
    public TMP_Text DebugPreviousPhase;
    public Button DebugPassPriority;

    public void Initialize(ulong ownerId, ClientServerBridge clientServerBridge)
    {
        Debug.Log("ClientUIController::Initialize");

        _ownerClientId = ownerId;
        _clientServerBridge = clientServerBridge;

        SubscribeToClientServerBridgeEvents();

        DebugPassPriority.onClick.AddListener(PassPriority);
    }

    private void SubscribeToClientServerBridgeEvents()
    {
        Debug.Log("ClientUIController::SubscribeToClientServerBridgeEvents");

        _clientServerBridge.TestAction += ClientServerBridge_TestAction;
        _clientServerBridge.EnterGamePhase += ClientServerBridge_EnterGamePhase;
        _clientServerBridge.ExitGamePhase += ClientServerBridge_ExitGamePhase;
    }

    private void ClientServerBridge_EnterGamePhase(GamePhase gamePhase)
    {
        Debug.Log("ClientUIController::ClientServerBridge_EnterGamePhase");
        DebugCurrentPhase.SetText(gamePhase.ToString());
    }

    private void ClientServerBridge_ExitGamePhase(GamePhase gamePhase)
    {
        Debug.Log("ClientUIController::ClientServerBridge_ExitGamePhase");
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
}
