using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpawnerScript : MonoBehaviour
{
    public GameObject[] objSpawnable;
    void Start()
    {
        int spawnObj = Random.Range(0, objSpawnable.Length);
        GameObject anObject = Instantiate(objSpawnable[spawnObj], transform.position, Quaternion.identity);
        anObject.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
