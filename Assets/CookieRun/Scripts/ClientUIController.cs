using UnityEngine;

//TODO: This should really be a state machine
//TODO: Actually, this should not be a state machine, but we should have more than one class that subs to the events in CSB
public class ClientUIController : MonoBehaviour
{
    //TODO: Make private
    public ulong _ownerClientId;
    //TODO: Remove this var
    private ClientServerBridge _clientServerBridge;

    public void Initialize(ulong ownerId, ClientServerBridge clientServerBridge)
    {
        Debug.Log("ClientUIController::Initialize");

        _ownerClientId = ownerId;
        _clientServerBridge = clientServerBridge;

        SubscribeToClientServerBridgeEvents();
    }

    private void SubscribeToClientServerBridgeEvents()
    {
        Debug.Log("ClientUIController::SubscribeToClientServerBridgeEvents");

        _clientServerBridge.TestAction += ClientServerBridge_TestAction;
    }

    private void ClientServerBridge_TestAction()
    {
        Debug.Log("Test Action triggered Client UI Controller function!");
    }
}
