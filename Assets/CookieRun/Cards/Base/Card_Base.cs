using UnityEngine;
using UnityEngine.UI;

public class Card_Base : ScriptableObject
{
    private bool _isRested = false;

    public virtual string CardId => CookieRunConstants.INVALID_CARD_ID;
    public virtual string CardNumber => CookieRunConstants.INVALID_CARD_ID;
    public virtual string CardName => CookieRunConstants.INVALID_CARD_ID;
    public virtual string CardText => CookieRunConstants.INVALID_CARD_ID;
    public virtual CardRarity CardRarity => CardRarity.Common;
    public virtual CardType CardType => CardType.Invalid;
    public virtual CardColour ColourIdentity => CardColour.Invalid;
    public virtual string ImageName => CookieRunConstants.CARD_BACK_IMAGE_NAME;
    public virtual bool IsRested => _isRested;

    public GameObject CardVisual;

    public int MatchID;

    public void Awake() 
    { 
        //TODO: Set the data, populate the card visual
    }

    public void OnPlay()
    {
        //TODO: Setup health pool
    }

    public void RestCard()
    {
        _isRested = true;
    }
    //TODO: Better name
    public void ActiveCard()
    {
        _isRested = false;
    }
}
