using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{

    public float timeShoot;
    public int angle;
    public GameObject bullet;

    private void Update()
    {
        
    }
    public Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    IEnumerator ShootCircle()
    {
        yield return new WaitForSeconds(timeShoot);
        Vector3 center = transform.position;
        Vector3 pos = RandomCircle(center, 2.0f, angle);
        GameObject aSword = Instantiate(bullet, pos, Quaternion.identity);
        angle += 30;
        if (angle == 360)
        {
            angle = 0;
        }
        if (enabled)
        {
            StartCoroutine(ShootCircle());
        }
    }
}
