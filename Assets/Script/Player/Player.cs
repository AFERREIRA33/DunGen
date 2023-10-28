using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 movement;

    public int money = 0;
    private int oldMoney = 0;
    public TextMeshProUGUI coinText;

    public int oldMaxLife;
    public int maxLife = 6;
    public HealthBarScript healthBarScript;
    [HideInInspector] public int actualLife;
    // Start is called before the first frame update
    void Start()
    {
        actualLife = maxLife;
        oldMaxLife = maxLife;
        healthBarScript.InstantiateLife();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (oldMoney != money)
        {
            oldMoney = money;
            coinText.text = money.ToString();
        }
        if (oldMaxLife != maxLife) 
        { 
            oldMaxLife = maxLife;
            healthBarScript.AddHeart(maxLife/2 - 1);
            healthBarScript.SetLife(actualLife);
        }
    }

    private void FixedUpdate()
    {
        Vector2 rbPos = new Vector2(rb.position.x, rb.position.y);
        rb.MovePosition(rbPos+ movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            actualLife--;
            healthBarScript.SetLife(actualLife);
        }
    }

}

