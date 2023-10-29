using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase4 : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject spawnPoint;
    public int timeShoot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;   
        Vector3 rotation = playerPos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeShoot);
        GameObject anEnemy = Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        anEnemy.transform.parent = transform.parent;
        anEnemy.GetComponentInChildren<ShootingEnemy>().enabled = true;
        if (enabled)
        {
            StartCoroutine(Spawn());
        }
    }
}
