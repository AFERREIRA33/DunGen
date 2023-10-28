using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float rotationSpeed = 30;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            if (collision.gameObject.name.Contains("Bullet"))
            {
                Destroy(collision.gameObject);
            } else
            {
                collision.gameObject.GetComponent<EnemyScript>().enemyLifePoint--;
            }
            parent.GetComponent<RotateScript>().StartCoroutine("RespawnSword");
            Destroy(gameObject);
        }
    }
}
