using UnityEngine;
using UnityEngine.UI;

public class Card_Base : ScriptableObject
{
    private bool _isRested = false;

    public string CardId = CookieRunConstants.INVALID_CARD_ID;
    public string CardNumber = CookieRunConstants.INVALID_CARD_ID;
    public string CardName = CookieRunConstants.INVALID_CARD_ID;

    public CardRarity CardRarity = CardRarity.Common;
    public CardType CardType = CardType.Invalid;
    public CardColour ColourIdentity = CardColour.Invalid;

    public Texture2D CardTexture;
    
    public int MatchID;

    public void Awake() 
    { 
        //TODO: Set the data, populate the card visual
    }

    public virtual void OnPlay()
    {
        
    }

    public bool GetIsRested()
    {
        return _isRested;
    }
    public void ChangeStateToRest()
    {
        _isRested = true;
    }
    public void ChangeStateToActive()
    {
        _isRested = false;
    }
}
