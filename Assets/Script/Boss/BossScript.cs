using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public int pastLife;
    public int bossLife = 50;
    public Slider lifeBar;
    public bool phaseChoosed = false;
    public int numPhase = 4;
    public GameManager gameManager;
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Update()
    {
        if (pastLife != bossLife)
        {
            pastLife = bossLife;
            lifeBar.value = pastLife;
        }
        if (bossLife <= 0)
        {
            gameManager.GameOver(true);
            Destroy(gameObject);

        }
        if (bossLife % 10 == 0 && !phaseChoosed)
        {
            PhaseChoice();
            phaseChoosed=true;
        } 
        if (bossLife % 10 != 0) 
        {
            phaseChoosed = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PlayerBullet"))
        {
            bossLife--;
        }
    }

    public void PhaseChoice()
    {
        int phase = Random.Range(0, numPhase);
        GetComponent<ShootingEnemy>().enabled = false;
        GetComponent<Phase2>().enabled = false;
        GetComponent<Phase3>().enabled = false;
        GetComponent<Phase4>().enabled = false;
        switch(phase) 
        { 
            case 0:
                GetComponent<ShootingEnemy>().enabled = true;
                GetComponent<ShootingEnemy>().first = true;
                break;
            case 1:
                GetComponent<Phase2>().enabled = true;
                GetComponent<Phase2>().StartCoroutine("ShootCircle");

                break;

            case (2):
                GetComponent<Phase3>().enabled = true;
                GetComponent<Phase3>().StartCoroutine("Dash");

                break;
            default:
                GetComponent<Phase4>().enabled = true;
                GetComponent<Phase4>().StartCoroutine("Spawn");
                break;
        }
    }

}
