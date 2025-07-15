using UnityEngine;
using UnityEngine.UI;

public class Card_Base : MonoBehaviour
{
    public virtual string CardId => "";
    public virtual string CardNumber => "";
    public virtual string CardName => "";
    public virtual string CardText => "";
    public virtual CardRarity CardRarity => CardRarity.Common;
    public virtual CardType CardType => CardType.Invalid;
    public virtual CardColour ColourIdentity => CardColour.Invalid;
    public virtual string ImagePath => "";

    public Image CardImage;
}
