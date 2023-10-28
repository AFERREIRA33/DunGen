using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public GameObject[] objDrops;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine("Spawn");
        }
    }

    public IEnumerator Spawn()
    {
        
        yield return new WaitForSeconds(2);
        int objSpawn = Random.Range(0, objDrops.Length);
        Instantiate(objDrops[objSpawn], transform.position, Quaternion.identity);
        Destroy(gameObject);
        yield return null;

    }
}
