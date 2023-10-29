using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3 : MonoBehaviour
{
    public GameObject player;
    public int force;
    public Rigidbody2D rb;
    public float timeDash;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        
    }
    IEnumerator Dash()
    {
        yield return new WaitForSeconds(timeDash);
        Vector3 playerPos = player.transform.position;
        Vector3 direction = playerPos - transform.position;
        Vector3 rotation = transform.position - playerPos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        if (enabled)
        {
            StartCoroutine(Dash());
        }
    }
}
