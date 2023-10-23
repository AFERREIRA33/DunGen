using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite[] heartSprite;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = heartSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}