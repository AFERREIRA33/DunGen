using Mono.CompilerServices.SymbolWriter;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
        public bool isBoss = false;
    }

    [System.Serializable]
    public class Rule
    {
        public GameObject room;
        public Vector2Int minPos;
        public Vector2Int maxPos;
        public bool obligatory;

        public int NumberOfRoom = -1;
        public int ProbalityOfSpawning(int x,int y)
        {
            if (x >= minPos.x && x <= maxPos.x && y >= minPos.y && y <= maxPos.y)
            {
                return obligatory ? 2 : 1;
            }
            return 0;
        }
    }
 
    public Vector2 size;
    public int startPos = 0;
    public Rule[] rooms;
    public Vector2 offset;

    List<Cell> board;

    void Start()
    {
        MazeGenerator();
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j * size.x)];
                if (currentCell.visited) 
                {
                    int randomRoom = -1;
                    List<int> availableRooms = new List<int>();
                    if (currentCell.isBoss)
                    {
                        randomRoom = 1;
                    } else
                    {
                        for (int k = 0; k < rooms.Length; k++)
                        {
                            int p = rooms[k].ProbalityOfSpawning(i, j);
                            if (p == 2)
                            {
                                randomRoom = k;
                                break;
                            }
                            else if (p == 1 && rooms[k].NumberOfRoom != 0)
                            {
                                availableRooms.Add(k);
                            }
                        }
                    }
                    if (randomRoom == -1 )
                    {
                        if (availableRooms.Count > 0)
                        {
                            randomRoom = availableRooms[Random.Range(0, availableRooms.Count)];
                        } else
                        {
                            randomRoom = 0;
                        }
                    }
                    if (rooms[randomRoom].NumberOfRoom > 0)
                    {
                        rooms[randomRoom].NumberOfRoom--;
                    }
                    var newRoom = Instantiate(rooms[randomRoom].room, new Vector2(i * offset.x, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavior>();
                    
                    newRoom.UpdateRoom(board[Mathf.FloorToInt(i + j * size.x)].status);

                    newRoom.name += " " + i + " " + j;
                }
            }
        }
    }
    void MazeGenerator()
    {
        int doorsOpen = 0;
        board = new List<Cell>();
        List<int> possibleBoss = new List<int>();
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++) 
            { 
                board.Add(new Cell());
            }
        }
        int currentCell = startPos;
        Stack<int> path = new Stack<int>();
        int k = 0;
        while(k < 1000)
        {
            k++;
            board[currentCell].visited = true;
            List<int> neighbors = CheckNeighbors(currentCell);
            if (neighbors.Count == 0)
            {
                if(path.Count == 0)
                {
                    break;
                } else
                {
                    doorsOpen = 0;
                    for (int i = 0; i < board[currentCell].status.Length; i++)
                    {
                        if (currentCell != 0)
                        {
                            doorsOpen = board[currentCell].status[i] ? doorsOpen + 1 : doorsOpen;
                        }
                    }
                    if (doorsOpen == 1)
                    {
                        possibleBoss.Add(currentCell);
                    }
                    currentCell = path.Pop();
                }
            } else
            {
                path.Push(currentCell);
                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                if(newCell > currentCell)
                {
                    if(newCell -1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    } else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }
                } else
                {
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }
                }
            }
        }
        int bossRoom = Random.Range(0, possibleBoss.Count);
        board[possibleBoss[bossRoom]].isBoss = true;
        GenerateDungeon();
    }
    List<int> CheckNeighbors(int cell) 
    { 
        // check up neighbor
        List<int> neighbors = new List<int>();
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }

        // check down neighbor
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }

        // check right neighbor
        if ((cell+1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        // check left neighbor
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }
}
