using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject bullet;
    public Transform transformBullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = playerPos.transform.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bullet, transformBullet.position, Quaternion.identity);
        StartCoroutine(Shoot());
    }
}
