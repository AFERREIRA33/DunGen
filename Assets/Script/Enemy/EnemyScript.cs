using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private ShootingEnemy se;
    public int enemyLifePoint  = 3;
    private RoomBehavior roomBehavior;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        se = GetComponentInChildren<ShootingEnemy>();
        player = GameObject.FindGameObjectWithTag("Player");
        roomBehavior = GetComponentInParent<RoomBehavior>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector2.Distance(player.transform.position, transform.position) <= 10f) 
        //{
        //    se.enabled = true;
        //} else
        //{
        //    se.enabled = false;
        //}

        if (enemyLifePoint <= 0)
        {
            roomBehavior.enemyNum--;
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PlayerBullet"))
        {
            enemyLifePoint--;
        }
    }
}
