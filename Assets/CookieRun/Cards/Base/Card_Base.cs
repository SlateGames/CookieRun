using UnityEngine;
using UnityEngine.UI;

public class Card_Base : ScriptableObject
{
    public virtual string CardId => "";
    public virtual string CardNumber => "";
    public virtual string CardName => "";
    public virtual string CardText => "";
    public virtual CardRarity CardRarity => CardRarity.Common;
    public virtual CardType CardType => CardType.Invalid;
    public virtual CardColour ColourIdentity => CardColour.Invalid;
    public virtual string ImageName => "";

    public GameObject CardVisual;

    public int MatchID;

    public Card_Base() 
    { 
        //TODO: Set the data, populate the card visual
    }

    public void OnPlay()
    {
        //TODO: Setup health pool
    }
}
