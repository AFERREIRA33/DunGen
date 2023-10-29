using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] doors;
    public bool[] isOpen;
    private GameObject player;
    public int enemyNum;
    public Canvas bossHUD;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
    }
    public void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= 10f && (name.Contains("Enemy") || name.Contains("Boss")) && enemyNum > 0)
        {
            for (int i = 0; i < isOpen.Length; i++)
            {
                walls[i].SetActive(true);
            }
            if (gameObject.name.Contains("Boss"))
            {
                bossHUD.gameObject.SetActive(true);

            } else
            {
                ShootingEnemy[] sE = GetComponentsInChildren<ShootingEnemy>();
                foreach (ShootingEnemy room in sE)
                {
                    room.enabled = true;
                }
            }
        } 
        if (enemyNum <= 0 ){
            UpdateRoom(isOpen);
        }
    }
    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++) 
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
        isOpen = status;
    }

}
