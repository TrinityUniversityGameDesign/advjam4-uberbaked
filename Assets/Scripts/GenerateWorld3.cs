using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld3 : MonoBehaviour
{

    public int row;
    public int col;

    public GameObject wallOrig;
    public GameObject floorOrig;
    public GameObject boxOrig;
    public GameObject grindOrig;
    public GameObject rollOrig;
    public GameObject deliverOrig;
    public GameObject tile;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public int[,] grid;

    public GameObject boardHolder;

    // Use this for initialization
    void Start()
    {
        row = 10;
        col = 10;
        createWorld();
        addToWorld();
        addPlayers();
    }

    void addPlayers()
    {
        Vector3 spawn = new Vector3(3f, 3.2f, 0f);
        Instantiate(player1, spawn, Quaternion.identity);
        Instantiate(player2, spawn, Quaternion.identity);
        Instantiate(player3, spawn, Quaternion.identity);
        Instantiate(player4, spawn, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Destroying World");
            destroyWorld();
            createWorld();
            addToWorld();
        }
    }

    void createWorld()
    {
        grid = new int[row, col];
        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < col; ++j)
            {
                //if(i == 0 || j == 0 || i == row-1 || j == col-1){
                //	grid[i,j] = 1;
                //}
                if (i == 1 || j == 1 || i == row - 2 || j == col - 2)
                {
                    grid[i, j] = 0;
                }
                else
                {
                    grid[i, j] = 1;
                }

            }
        }
        grid[0, 1] = 1;
        grid[1, col - 1] = 1;
        grid[0, col - 2] = 1;
        grid[row - 2, 0] = 1;
        grid[row - 1, 1] = 1;
        grid[1, 0] = 1;
        grid[row - 2, col - 1] = 1;
        grid[row - 1, col - 2] = 1;

        grid[0, 5] = 2;
        grid[5, 0] = 5;
        grid[4, 0] = 5;
        grid[row - 1, 5] = 3;
        grid[5, col - 1] = 4;

    }

    void addToWorld()
    {
        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < col; ++j)
            {
                Vector3 position = new Vector3(i, j, 0f);

                switch (grid[i, j])
                {
                    case 0:
                        position = new Vector3(i, j, 0f);
                        tile = Instantiate(floorOrig, position, Quaternion.identity) as GameObject;
                        break;
                    case 1:
                        position = new Vector3(i, j, 1f);
                        tile = Instantiate(wallOrig, position, Quaternion.identity) as GameObject;
                        break;
                    case 2:
                        position = new Vector3(i, j, 1f);
                        tile = Instantiate(boxOrig, position, Quaternion.identity) as GameObject;
                        break;
                    case 3:
                        position = new Vector3(i, j, 1f);
                        tile = Instantiate(grindOrig, position, Quaternion.identity) as GameObject;
                        break;
                    case 4:
                        position = new Vector3(i, j, 1f);
                        tile = Instantiate(rollOrig, position, Quaternion.identity) as GameObject;
                        break;
                    case 5:
                        position = new Vector3(i, j, 1f);
                        tile = Instantiate(deliverOrig, position, Quaternion.identity) as GameObject;
                        break;
                    default:
                        break;
                }

                tile.transform.parent = boardHolder.transform;
            }

        }
        boardHolder.transform.Rotate(-90f, 0f, 0f);
    }

    void destroyWorld()
    {
        foreach (Transform child in boardHolder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }


}
