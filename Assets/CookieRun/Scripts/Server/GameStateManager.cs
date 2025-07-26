using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public enum GamePhase
{
    Setup,
    Active,
    Draw,
    Support,
    Main,
    Battle,
    End
}

public enum SetupPhase
{
    GamePreparation,
    Mulligans,
    PreGameCookiePlacement,
}

public enum BattlePhase
{
    Attack,
    Trap,
    Resolution
}


//TODO: Should I have a GameZone_Manager?
public class GameStateManager
{
    private bool HasPlayer1BeenRegistered = false;
    private bool HasPlayer2BeenRegistered = false;

    public ulong Player1Id;
    public ulong Player2Id;

    private ulong _activePlayerId;
    private GameState_Base _currentState;

    public short CurrentTurn;

    public bool IsValidPlayer(ulong playerId) => playerId == Player1Id || playerId == Player2Id;

    public GameStateManager()
    {
        Debug.Log("GameStateManager::GameStateManager");

        CurrentTurn = 0;
        _activePlayerId = RulesEngine.INVALID_PLAYER_ID;

        //RulesEngine.Instance.PlayerDeathEvent += RulesEngine_PlayerDeathEvent;
    }

    public void Initialize()
    {
        Debug.Log("GameStateManager::Initialize");
        ChangeState(new GameState_Setup());
    }

    public bool RegisterPlayer(ulong playerId, Deck deck)
    {
        Debug.Log("GameStateManager::RegisterPlayer");

        bool registrationResult = ConfigurePlayer(playerId);
        Debug.Log($"GameStateManager: Registration result {registrationResult}.");

        if (registrationResult)
        {
            Debug.Log("GameStateManager: Registering player zones.");
            RulesEngine.Instance.GetGameZoneManager().RegisterPlayer(playerId);

            Debug.Log("GameStateManager: Registering deck.");
            RulesEngine.Instance.GetCardManager().RegisterDeckForPlayer(playerId, deck);
        }

        return registrationResult;
    }

    public void RegisterBotPlayer(ulong playerId, Deck deck)
    {
        Debug.Log("GameStateManager::RegisterBotPlayer");
        RegisterPlayer(RulesEngine.INVALID_PLAYER_ID, deck);
    }

    public bool ConfigurePlayer(ulong playerId)
    {
        Debug.Log("GameStateManager::ConfigurePlayer");

        if (HasPlayer1BeenRegistered == false)
        {
            Debug.Log("GameState: Registering Player 1 as: " + playerId);

            Player1Id = playerId;
            HasPlayer1BeenRegistered = true;
            return true;
        }
        else if (HasPlayer2BeenRegistered == false)
        {
            Debug.Log("GameState: Registering Player 2 as: " + playerId);

            Player2Id = playerId;
            HasPlayer2BeenRegistered = true;
            return true;
        }
        else
        {
            Debug.LogError("Attempting to register a third participant. Player 1 ID: " + Player1Id + ". Player 2 ID: " + Player2Id + ". Invalid player ID: " + playerId);
        }

        Debug.Log("GameState: Unable to regiseter " + playerId + " as a Player.");
        return false;
    }
    
    public ulong GetActivePlayerId()
    {
        return _activePlayerId;
    }

    public ulong GetOpponentId(ulong playerId)
    {
        Debug.Log("GameStateManager::GetOpponentId");

        if (!IsValidPlayer(playerId))
        {
            Debug.LogWarning("This is not a valid player");
            return RulesEngine.INVALID_PLAYER_ID;
        }

        return playerId == Player1Id ? Player2Id : Player1Id;
    }

    private void RulesEngine_PlayerDeathEvent(ulong deadPlayerId)
    {
        Debug.Log("GameStateManager::RulesEngine_PlayerDeathEvent");
        EndMatch(deadPlayerId);
    }

    private async void EndMatch(ulong losingPlayerId)
    {
        Debug.Log("GameStateManager::EndMatch");
        //TODO: Update database
    }

    //TODO: One of these needs to be renamed
    public void EndTurn()
    {
        _activePlayerId = _activePlayerId == Player1Id ? Player2Id : Player1Id;
    }

    public void EndTurn(ulong passingPlayer)
    {
        GameState_Main mainState = (GameState_Main)_currentState;
        if(mainState == null)
        {
            Debug.LogWarning($"Player {passingPlayer} is attempting to end the turn while in the {_currentState.GetPhase()}");
            return;
        }

        PassPriority(passingPlayer);
    }

    public void PassPriority(ulong passingPlayerId)
    {
        Debug.Log("GameStateManager::PassPriority");
        _currentState.PassPriority(passingPlayerId);
    }

    public void SkipSupport(ulong skippingPlayer)
    {
        GameState_Support supportState = (GameState_Support)_currentState;
        if(supportState == null)
        {
            Debug.LogWarning($"Player {skippingPlayer} is attempting to skip Support while in the {_currentState.GetPhase()}");
            return;
        }

        PassPriority(skippingPlayer);
    }

    public GamePhase GetCurrentPhase()
    {
        return _currentState.GetPhase();
    }

    public void DealNonCombatDamageToCookie(int sourceCardMatchId, int targetCardMatchId, int damageAmount)
    {
        Debug.Log("GameStateManager::DealNonCombatDamageToCookie");

        if (damageAmount <= 0)
        {
            Debug.Log("Damage amount is 0");
            return;
        }

        Card_Cookie targetCard = (Card_Cookie)RulesEngine.Instance.GetCardManager().GetCardByMatchId(targetCardMatchId);
        if(targetCard == null)
        {
            Debug.LogError("No card with Match ID " + targetCardMatchId + " exists.");
            return;
        }
        for (int i = 0; i < damageAmount; i++)
        {
            //TODO: Flip the card and stuff
            int cardToFlip = targetCard.TakeDamage();
        }
    }

    public void HealCookie(int sourceCardMatchId, int targetCardMatchId, int healAmount)
    {
        Debug.Log("GameStateManager::HealCookie");

        if (healAmount <= 0)
        {
            Debug.Log("Amount to heal is 0");
            return;
        }

        Card_Cookie targetCard = (Card_Cookie)RulesEngine.Instance.GetCardManager().GetCardByMatchId(targetCardMatchId);
        if (targetCard == null)
        {
            Debug.LogError("No card with Match ID " + targetCardMatchId + " exists.");
            return;
        }

        targetCard.Heal(healAmount);
    }

    public void ChangeState(GameState_Base newState)
    {
        Debug.Log("GameStateManager::ChangeState");

        if (newState == null)
        {
            Debug.LogError("New state is null");
            return;
        }

        if(_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter();
    }
}
