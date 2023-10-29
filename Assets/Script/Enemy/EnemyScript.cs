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
    public GameObject[] coins;
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
        if (enemyLifePoint <= 0)
        {
            roomBehavior.enemyNum--;
            int spawnCoin = Random.Range(-1, coins.Length);
            if (spawnCoin >= 0)
            {
                Instantiate(coins[spawnCoin], new Vector3(transform.position.x, transform.position.y, -2) , Quaternion.identity);
            }
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
