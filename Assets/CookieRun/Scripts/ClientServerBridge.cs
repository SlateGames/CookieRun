using UnityEngine;
using Unity.Netcode;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Matchmaker.Models;
using UnityEngine.XR;

//TODO: Make a base class for this and the Spectator? Things like the OnNetworkSpawn and InitComps could be defined there 

public class ClientServerBridge : NetworkBehaviour
{
    public event Action<ulong, GamePhase> PlayerEnterGamePhase;
    public event Action<ulong, GamePhase> PlayerExitGamePhase;
    public event Action<DeckDataPayload> DeckRegisteredForPlayer;
    public event Action<ulong> DeckShuffled;
    public event Action<ulong, string, int, GameZoneType, GameZoneType> CardChangeZone;
    public event Action MulligansStart;
    public event Action MulligansEnd;
    public event Action GameStart;
    public event Action<ulong> NewActivePlayer;

    public override void OnNetworkSpawn()
    {
        Debug.Log("ClientServerBridge::OnNetworkSpawn");

        base.OnNetworkSpawn();

        Debug.Log($"Player spawned. IsOwner: {IsOwner}, IsClient: {IsClient}, IsServer: {IsServer}");

        Initialize();
    }

    public async void Initialize()
    {
        Debug.Log("ClientServerBridge::Initialize");

        if (IsOwner)
        {
            Debug.Log($"ClientServerBridge: Spawned for Player {OwnerClientId}");

            HandleSetupCompleted();
        }
        if (IsServer)
        {
            Debug.Log($"ClientServerBridge: Spawned for Player {OwnerClientId}");
            SubscribeToServerEvents();

            //TODO: Figure out how to register and then enter setup phase
            var currentPhase = RulesEngine.Instance.GetGameStateManager().GetCurrentPhase();
            RulesEngine_PlayerPlayerEnterGamePhaseEvent(OwnerClientId, currentPhase);
        }
    }

    private async void SubscribeToServerEvents()
    {
        Debug.Log("ClientServerBridge::SubscribeToServerEvents");

        RulesEngine.Instance.DeckRegisteredForPlayerEvent += RulesEngine_DeckRegisteredForPlayerEvent;
        RulesEngine.Instance.DeckShuffledEvent += RulesEngine_DeckShuffledEvent;
        RulesEngine.Instance.CardChangeZoneEvent += RulesEngine_CardChangeZoneEvent;
        RulesEngine.Instance.MulligansStartEvent += RulesEngine_MulligansStartEvent;
        RulesEngine.Instance.MulligansEndEvent += RulesEngine_MulligansEndEvent;
        RulesEngine.Instance.GameStartEvent += RulesEngine_GameStartEvent;
        RulesEngine.Instance.NewActivePlayerEvent += RulesEngine_NewActivePlayerEvent;
        RulesEngine.Instance.PlayerPlayerEnterGamePhaseEvent += RulesEngine_PlayerPlayerEnterGamePhaseEvent;
        RulesEngine.Instance.PlayerPlayerExitGamePhaseEvent += RulesEngine_PlayerPlayerExitGamePhaseEvent;
    }

    private void RulesEngine_DeckRegisteredForPlayerEvent(DeckDataPayload deckData)
    {
        Debug.Log("ClientServerBridge::RulesEngine_DeckRegisteredForPlayerEvent");
        DeckRegisteredForPlayerClientRpc(deckData);
    }

    [ClientRpc]
    private void DeckRegisteredForPlayerClientRpc(DeckDataPayload deckData)
    {
        Debug.Log("ClientServerBridge::DeckRegisteredForPlayerClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        DeckRegisteredForPlayer?.Invoke(deckData);
    }

    private void RulesEngine_DeckShuffledEvent(ulong deckId)
    {
        Debug.Log("ClientServerBridge::RulesEngine_DeckShuffledEvent");
        DeckShuffledClientRpc(deckId);
    }

    [ClientRpc]
    private void DeckShuffledClientRpc(ulong deckId)
    {
        Debug.Log("ClientServerBridge::DeckShuffledClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        DeckShuffled?.Invoke(deckId);
    }

    private void RulesEngine_CardChangeZoneEvent(ulong playerId, string cardId, int cardMatchId, GameZoneType sourceZone, GameZoneType destinationZone)
    {
        Debug.Log("ClientServerBridge::RulesEngine_CardChangeZoneEvent");

        if (playerId != OwnerClientId)
        {
            if (destinationZone == GameZoneType.Deck || destinationZone == GameZoneType.Hand)
            {
                Debug.Log($"Player has ID {OwnerClientId}, which does not match passed ID {playerId}. The {destinationZone.ToString()} Zone is private, setting the Card Match ID from {cardMatchId} and the Card ID from {cardId} to UNKNOWN_CARD.");
                cardMatchId = CookieRunConstants.INVALID_CARD_MATCH_ID;
                cardId = CookieRunConstants.INVALID_CARD_ID;
            }
        }

        //TODO: Hide cards in the player's deck

        CardChangeZoneClientRpc(playerId, cardId, cardMatchId, sourceZone, destinationZone);
    }

    [ClientRpc]
    private void CardChangeZoneClientRpc(ulong playerId, string cardId, int cardMatchId, GameZoneType sourceZone, GameZoneType destinationZone)
    {
        Debug.Log("ClientServerBridge::CardChangeZoneClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        CardChangeZone?.Invoke(playerId, cardId, cardMatchId, sourceZone, destinationZone);
    }

    private void RulesEngine_MulligansStartEvent()
    {
        Debug.Log("ClientServerBridge::RulesEngine_MulligansStartEvent");
        MulligansStartClientRpc();
    }

    [ClientRpc]
    private void MulligansStartClientRpc()
    {
        Debug.Log("ClientServerBridge::MulligansStartClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        MulligansStart?.Invoke();
    }

    private void RulesEngine_MulligansEndEvent()
    {
        Debug.Log("ClientServerBridge::RulesEngine_MulligansEndEvent");
        MulligansEndClientRpc();
    }

    [ClientRpc]
    private void MulligansEndClientRpc()
    {
        Debug.Log("ClientServerBridge::MulligansEndClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        MulligansEnd?.Invoke();
    }

    private void RulesEngine_GameStartEvent()
    {
        Debug.Log("ClientServerBridge::RulesEngine_GameStartEvent");
        GameStartClientRpc();
    }

    [ClientRpc]
    private void GameStartClientRpc()
    {
        Debug.Log("ClientServerBridge::GameStartClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        GameStart?.Invoke();
    }

    private void RulesEngine_NewActivePlayerEvent(ulong playerId)
    {
        Debug.Log("ClientServerBridge::RulesEngine_NewActivePlayerEvent");
        NewActivePlayerClientRpc(playerId);
    }

    [ClientRpc]
    private void NewActivePlayerClientRpc(ulong playerId)
    {
        Debug.Log("ClientServerBridge::NewActivePlayerClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        NewActivePlayer?.Invoke(playerId);
    }

    private void RulesEngine_PlayerPlayerEnterGamePhaseEvent(ulong playerId, GamePhase gamePhase)
    {
        Debug.Log("ClientServerBridge::RulesEngine_PlayerPlayerEnterGamePhaseEvent");
        PlayerEnterGamePhaseClientRpc(playerId, gamePhase);
    }

    [ClientRpc]
    private void PlayerEnterGamePhaseClientRpc(ulong playerId, GamePhase gamePhase)
    {
        Debug.Log("ClientServerBridge::PlayerEnterGamePhaseClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        PlayerEnterGamePhase?.Invoke(playerId, gamePhase);
    }

    private void RulesEngine_PlayerPlayerExitGamePhaseEvent(ulong playerId, GamePhase gamePhase)
    {
        Debug.Log("ClientServerBridge::RulesEngine_PlayerPlayerExitGamePhaseEvent");
        PlayerExitGamePhaseClientRpc(playerId, gamePhase);
    }

    [ClientRpc]
    private void PlayerExitGamePhaseClientRpc(ulong playerId, GamePhase gamePhase)
    {
        Debug.Log("ClientServerBridge::PlayerExitGamePhaseClientRpc");

        if (IsOwner == false)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object.");
            return;
        }

        PlayerExitGamePhase?.Invoke(playerId, gamePhase);
    }

    //TODO: Revert the deck back to a deck id once the database is up
    [ServerRpc]
    public void RegisterPlayerServerRpc(ulong playerId, Deck deck)
    {
        Debug.Log("ClientServerBridge::RegisterPlayerServerRpc");
        RulesEngine.Instance.GetGameStateManager().RegisterPlayer(playerId, deck);
        RulesEngine.Instance.GetGameStateManager().RegisterBotPlayer(playerId, deck);
    }

    [ServerRpc]
    public void PassPriorityServerRpc(ulong passingPlayerId)
    {
        Debug.Log("ClientServerBridge::PassPriorityServerRpc");
        if (OwnerClientId != passingPlayerId)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object. Passing Player: {passingPlayerId}");
            return;
        }

        if(RulesEngine.Instance.GetGameStateManager().GetActivePlayerId() != passingPlayerId)
        {
            Debug.Log($"Player {passingPlayerId} is not the active player");
            return;
        }

        Debug.Log($"Player {passingPlayerId} is allowed to pass prioirity");
        RulesEngine.Instance.GetGameStateManager().PassPriority(passingPlayerId);
    }

    [ServerRpc]
    public void SkipSupportServerRpc(ulong skippingPlayerId)
    {
        Debug.Log("ClientServerBridge::SkipSupportServerRpc");
        if (OwnerClientId != skippingPlayerId)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object. Skipping Player: {skippingPlayerId}");
            return;
        }

        if (RulesEngine.Instance.GetGameStateManager().GetActivePlayerId() != skippingPlayerId)
        {
            Debug.Log($"Player {skippingPlayerId} is not the active player");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().SkipSupport(skippingPlayerId);
    }

    [ServerRpc]
    public void EndTurnServerRpc(ulong passingPlayerId)
    {
        Debug.Log("ClientServerBridge::EndTurnServerRpc");
        if (OwnerClientId != passingPlayerId)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object. Passing Player: {passingPlayerId}");
            return;
        }

        if (RulesEngine.Instance.GetGameStateManager().GetActivePlayerId() != passingPlayerId)
        {
            Debug.Log($"Player {passingPlayerId} is not the active player");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().EndTurn(passingPlayerId);
    }

    private void HandleSetupCompleted()
    {
        Debug.Log("ClientServerBridge::HandleSetupCompleted");
        FindObjectOfType<ClientUIController>().Initialize(OwnerClientId, this);
    }

    [ServerRpc]
    public void PlayerRequestsMulligansServerRpc(ulong playerId)
    {
        Debug.Log("ClientServerBridge::PlayerRequestsMulligansServerRpc");

        if (OwnerClientId != playerId)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object. Player requesting a mulligan: {playerId}");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().HandleMulliganRequestForPlayer(playerId);
    }

    [ServerRpc]
    public void PlayerRefusesMulligansServerRpc(ulong playerId)
    {
        Debug.Log("ClientServerBridge::PlayerRefusesMulligansServerRpc");

        if (OwnerClientId != playerId)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object. Player requesting a mulligan: {playerId}");
            return;
        }

        RulesEngine.Instance.GetGameStateManager().HandleMulliganRefusalForPlayer(playerId);
    }

    [ServerRpc]
    public void OnHandCardClickedServerRpc(ulong playerId, int cardMatchId)
    {
        Debug.Log("ClientServerBridge::OnHandCardClicked");

        if (OwnerClientId != playerId)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object. Player clicking a Hand Card: {playerId}");
            return;
        }

        
    }

    [ServerRpc]
    public void OnSupportCardClickedServerRpc(ulong playerId, int cardMatchId)
    {
        Debug.Log("ClientServerBridge::OnSupportCardClicked");

        if (OwnerClientId != playerId)
        {
            Debug.Log($"Player {OwnerClientId} does not own this object. Player clicking a Support Card: {playerId}");
            return;
        }

        
    }
}