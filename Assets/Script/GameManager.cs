using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EndScreen;
    public GameObject PauseScreen;
    public TextMeshProUGUI endTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameOver(bool win)
    {
        if (win)
        {
            endTxt.text = "You win! GG WP!";
            EndScreen.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            endTxt.text = "You loose! Skill issue!";
            EndScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
