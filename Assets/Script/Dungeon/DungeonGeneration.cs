using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public GameObject[] EventRooms;
    public GameObject[] EnemyRooms;
    public GameObject[] ChestRooms;
    public GameObject[] BossRooms;
    
    public class Cell
    {
        public bool visited = false;
        public bool[] status = null;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MazeGenrator()
    {

    }
    void CheckNeighbors() 
    { 
    
    }

}
