using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite[] heartSprite;
    public Image image;

    public void setHeart(int status)
    {
        image.sprite = heartSprite[status];
        Debug.Log(image.sprite.name);
    }
}