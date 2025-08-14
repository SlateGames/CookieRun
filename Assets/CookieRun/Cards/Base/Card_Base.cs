using System.Collections.Generic;
using UnityEngine;

//Some decks: https://firefist.gg/rams-purple-cookies/

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
    TuckLevelOneCookie,
    TrashLevelOneCookie,
}

public class AbilityContextData
{
    public List<int> TargetMatchIds = new List<int>();
    public List<ulong> TargetPlayerIds = new List<ulong>();
    public int Amount = 1;
    public int AbilityId = 0;
}

public class CardAbility
{
    public string AbilityText = string.Empty;
    public List<CardColour> ManaCost = new List<CardColour>();
    public List<NonManaCost> OtherCosts = new List<NonManaCost>();
    public List<AbilityQualifier> Qualifiers = new List<AbilityQualifier>();
}

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

    protected List<CardAbility> _abilities = new List<CardAbility>();

    public abstract void ActivateAbility(AbilityContextData abilityContext);

    public virtual void OnEnterZone(GameZoneType gameZone)
    {
        
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

    public virtual List<CardAbility> GetAbilities()
    {
        return _abilities;
    }

    public CardAbility GetAbility(int abilityId)
    {
        List<CardAbility> abilities = GetAbilities();
        if (abilityId >= 0 && abilityId < abilities.Count)
        {
            return abilities[abilityId];
        }

        return null;
    }

    public bool HasAbilities()
    {
        return GetAbilities().Count > 0;
    }
}
