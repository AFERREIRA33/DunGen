using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    int numObjects = 0;
    public GameObject prefab;
    public void Start()
    {
        
    }
    public void CreateSword()
    {
        Vector3 center = transform.position;
        Vector3 pos = RandomCircle(center, 2.0f, numObjects*30);
        GameObject aSword = Instantiate(prefab, pos, Quaternion.identity);
        aSword.transform.Rotate(new Vector3(0, 0, numObjects * -30));
        aSword.transform.parent = transform;
        numObjects++;
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
    public IEnumerator RespawnSword()
    {
        numObjects--;
        yield return new WaitForSeconds(10);
        CreateSword();
        yield return null;

    }

}
