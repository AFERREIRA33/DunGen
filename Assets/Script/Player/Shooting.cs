using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform transformBullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transformBullet.position, Quaternion.identity);
        }
    }
}
