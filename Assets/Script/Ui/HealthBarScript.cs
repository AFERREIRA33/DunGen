using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{

    public GameObject heart;
    public Player player;
    private int heartNum;
    
    public void setLife()
    {
        heartNum = player.maxLife;
        for (int i = 0; i < heartNum/2; i++)
        {
            Debug.Log("toto");
            GameObject aHeart = Instantiate(heart, new Vector2(transform.position.x - 5.5f + i, transform.position.y + 0.75f), Quaternion.identity);
            aHeart.transform.parent = transform;
        }
    }


}
