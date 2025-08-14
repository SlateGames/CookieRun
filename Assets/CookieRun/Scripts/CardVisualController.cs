using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisualController : MonoBehaviour
{
    [SerializeField] private Image cardImage;

    public void LoadImageFromName(string name)
    {
        string imageName = name.Replace(".png", "");

        if(name == CookieRunConstants.CARD_BACK_IMAGE_NAME)
        {
            ClearCard();
            return;
        }

        Texture2D texture = Resources.Load<Texture2D>("Cards/Images/BraveBeginnings/" + imageName);
        if (texture != null)
        {
            Sprite cardSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            if (cardImage != null)
            {
                cardImage.sprite = cardSprite;
            }
            else
            {
                Debug.LogWarning("No Image component found on " + gameObject.name);
            }
        }
        else
        {
            Debug.LogError("Could not load card image: " + name + " from path: Cards/Images/BraveBeginnings/" + imageName);
        }
    }

    public void ClearCard()
    {
        Texture2D texture = Resources.Load<Texture2D>("Cards/Images/card-back");
        if (texture != null)
        {
            Sprite cardSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            if (cardImage != null)
            {
                cardImage.sprite = cardSprite;
            }
            else
            {
                Debug.LogWarning("No Image component found on " + gameObject.name);
            }
        }
        else
        {
            Debug.LogError("Could not load card image from path: Cards/Images/card-back");
        }
    }
}