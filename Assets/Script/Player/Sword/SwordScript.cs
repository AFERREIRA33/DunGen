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
        if (collision.gameObject.name.Contains("Enemy") || collision.gameObject.name.Contains("Boss"))
        {
            if (collision.gameObject.name.Contains("Bullet"))
            {
                Destroy(collision.gameObject);
            } else if (collision.gameObject.name.Contains("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyScript>().enemyLifePoint--;
            } else
            {
                collision.gameObject.GetComponent<BossScript>().bossLife--;
            }
            parent.GetComponent<RotateScript>().StartCoroutine("RespawnSword");
            Destroy(gameObject);
        }
    }
}
