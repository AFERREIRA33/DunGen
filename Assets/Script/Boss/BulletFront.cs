using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class BulletFront : MonoBehaviour
{
    Vector3 bossPos;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        bossPos = GameObject.FindGameObjectWithTag("Boss").transform.position;
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction =  transform.position - bossPos;
        Vector3 rotation = bossPos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
