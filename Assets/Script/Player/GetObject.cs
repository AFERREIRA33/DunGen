using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    public GameObject sword;
    public GameObject rotationPoint;
    public int numSword;
    public Transform posSword;
    public TextMeshProUGUI swordTxt;
    public void SetSword(GameObject swordCol)
    {
        GetComponentInChildren<RotateScript>().CreateSword();
        Destroy(swordCol);
        numSword++;
        swordTxt.text = numSword.ToString();
    }
    public void SetHeart(GameObject heart)
    {
        Player player = GetComponent<Player>();
        if (heart.name.Contains("Demi"))
        {

            if (player.actualLife < player.maxLife)
            {
                player.actualLife++;
                player.healthBarScript.SetLife(player.actualLife);
                Destroy(heart);
            }
        }else if (heart.name.Contains("Container"))
        {
            player.maxLife += 2;
            Destroy(heart);
        } else
        {
            if (player.actualLife ==  player.maxLife -1)
            {
                player.actualLife++;
                player.healthBarScript.SetLife(player.actualLife);
                Destroy(heart);
            }
            else if (player.actualLife < player.maxLife - 1)
            {
                player.actualLife += 2;
                player.healthBarScript.SetLife(player.actualLife);
                Destroy(heart);
            }
        }
    }
}
