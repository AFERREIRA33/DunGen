using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{

    public void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.name.Contains("Player"))
        {
            if (gameObject.name.Contains("Heart"))
            {
                collision.gameObject.GetComponent<GetObject>().SetHeart(gameObject);
            } else
            {
                collision.gameObject.GetComponent<GetObject>().SetSword(gameObject);
            }
        }
    }
}
