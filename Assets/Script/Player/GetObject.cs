using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    public GameObject sword;
    public int numSword;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            if (collision.gameObject.name.Contains("Sword"))
            {
                SetSword();
            } else if (collision.gameObject.name.Contains("Heart"))
            {
                SetHeart(collision.gameObject);
            }
        }
    }

    private void SetSword()
    {

    }
    private void SetHeart(GameObject heart)
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
