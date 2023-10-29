using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpawnerScript : MonoBehaviour
{
    public GameObject[] objSpawnable;
    public Sprite[] prices;
    public GameObject price;
    private int value;
    void Start()
    {
        
        int spawnObj = Random.Range(0, objSpawnable.Length);
        Instantiate(objSpawnable[spawnObj], transform.position, Quaternion.identity);
        price.GetComponent<SpriteRenderer>().sprite = prices[spawnObj];
        value = int.Parse(prices[spawnObj].name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player>().money >= value)
            {
                collision.gameObject.GetComponent<Player>().money -= value;
                Destroy(gameObject);
            }
        }
    }


}
