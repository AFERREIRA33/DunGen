using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{

    public GameObject heart;
    public Player player;
    private int heartNum;
    private List<GameObject> hearts;
    
    public void InstantiateLife()
    {
        hearts = new List<GameObject>();
        heartNum = player.maxLife;
        for (int i = 0; i < heartNum/2; i++)
        {
            AddHeart(i);
            hearts[i].GetComponent<Heart>().setHeart(2);
        }
    }
    public void AddHeart(int heartNum)
    {
        GameObject aHeart = Instantiate(heart, new Vector2(transform.position.x - 5.5f + heartNum, transform.position.y + 0.75f), Quaternion.identity);
        aHeart.transform.parent = transform;
        hearts.Add(aHeart);
    }

    public void SetLife(int actualLife)
    {
        foreach (GameObject heart in hearts)
        {
            if (actualLife >1) 
            {
                heart.GetComponent<Heart>().setHeart(2);
                actualLife -= 2;
            } else if (actualLife == 1)
            {
                heart.GetComponent<Heart>().setHeart(1);
                actualLife -= 2;
            } else
            {
                heart.GetComponent<Heart>().setHeart(0);
            }
        }
    }

}
