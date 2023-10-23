using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    RoomBehavior roomBehavior;
    // Start is called before the first frame update
    void Start()
    {
        GameObject en;
        roomBehavior = GetComponentInParent<RoomBehavior>();
        int enemyNum = Random.Range(1, 5);
        roomBehavior.enemyNum = enemyNum;
        for (int i = 0;  i < enemyNum; i++)
        {
            en = Instantiate(enemy, new Vector2(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(-10, 10)), Quaternion.identity);
            en.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
