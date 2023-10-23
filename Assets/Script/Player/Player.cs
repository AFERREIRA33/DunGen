using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public int maxLife = 6;
    public HealthBarScript healthBarScript;
    [HideInInspector] public int actualLife;
    // Start is called before the first frame update
    void Start()
    {
        actualLife = maxLife;
        healthBarScript.setLife();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 rbPos = new Vector2(rb.position.x, rb.position.y);
        rb.MovePosition(rbPos+ movement * moveSpeed * Time.fixedDeltaTime);
    }

}

