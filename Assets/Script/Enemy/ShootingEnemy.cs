using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject bullet;
    public Transform transformBullet;
    public float timeShoot = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Shoot());
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
        yield return new WaitForSeconds(timeShoot);
        Instantiate(bullet, transformBullet.position, Quaternion.identity);
        if (enabled)
        {
            StartCoroutine(Shoot());
        }
    }
}
