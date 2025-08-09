using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AbilityQualifier
{
    Activate,
    Blocker,
    Flip,
    OnPlay,
    OncePerTurn,
    YourTurn
}

public enum NonManaCost
{
    RestCard,
    DiscardCard,
    TrashSupportCard,
    SacrificeOne,
    SetHealthToOne,
    TrashThisCard,
    BreakThisCard,
    BounceSupportCard,
    TuckLevelOneCookie
}

[System.Serializable]
public class CardAbility
{
    public List<CardColour> ManaCost = new List<CardColour>();
    public List<NonManaCost> NonManaCost = new List<NonManaCost>();
    public List<AbilityQualifier> Qualifiers = new List<AbilityQualifier>();
}

//"【Blocker】 《{R}》 (When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.)《{R}{N}》 Deals 1 damage.";

public abstract class Card_Base : ScriptableObject
{
    private bool _isRested = false;

    [SerializeField] protected List<CardAbility> _abilities = new List<CardAbility>();

    public string CardId = CookieRunConstants.INVALID_CARD_ID;
    public string CardNumber = CookieRunConstants.INVALID_CARD_ID;
    public string CardName = CookieRunConstants.INVALID_CARD_ID;
    public string CardText = CookieRunConstants.INVALID_CARD_ID;
    public CardRarity CardRarity = CardRarity.Common;
    public CardType CardType = CardType.Invalid;
    public CardColour ColourIdentity = CardColour.Invalid;
    public Texture2D CardTexture = null;

    [HideInInspector] public int MatchID;
    protected abstract CardType GetCardType();

    protected virtual void OnEnable()
    {
        if (CardType == CardType.Invalid)
        {
            CardType = GetCardType();
        }
    }

    public virtual void OnPlay()
    {
        //TODO: Setup health pool
    }

    public virtual void ActivateAbility(int abilityIndex)
    {
        //TODO: Get this working
    }

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