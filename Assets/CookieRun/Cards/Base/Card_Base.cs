using UnityEngine;

//Some decks: https://firefist.gg/rams-purple-cookies/

public abstract class Card_Base
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

    //public 

    public virtual bool GetIsRested()
    {
        return _isRested;
    }
    public void SetStateToRest()
    {
        _isRested = true;
    }
    public void SetStateToActive()
    {
        _isRested = false;
    }
}
