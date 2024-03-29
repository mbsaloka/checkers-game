using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject piece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerDark = new GameObject[12];
    private GameObject[] playerLight = new GameObject[12];

    private string currentPlayer = "dark";

    private bool gameOver = false;

    void Start()
    {
        int idx = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j += 2)
            {
                if (i % 2 == 0)
                {
                    playerDark[idx] = Create("dark_pawn", j, i);
                    playerLight[idx++] = Create("light_pawn", j + 1, i + 5);
                }
                else
                {
                    playerDark[idx] = Create("dark_pawn", j + 1, i);
                    playerLight[idx++] = Create("light_pawn", j, i + 5);
                }
            }
        }

        for (int i = 0; i < 12; i++)
        {
            SetPosition(playerDark[i]);
            SetPosition(playerLight[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(piece, new Vector3(0, 0, -1), Quaternion.identity);
        Piece pc = obj.GetComponent<Piece>();
        pc.name = name;
        pc.SetXBoard(x);
        pc.SetYBoard(y);
        pc.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Piece pc = obj.GetComponent<Piece>();
        positions[pc.GetXBoard(), pc.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || x > 7 || y < 0 || y > 7)
        {
            return false;
        }
        return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "dark")
        {
            currentPlayer = "light";
        }
        else
        {
            currentPlayer = "dark";
        }
    }

    public void update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            SceneManager.LoadScene("GameScene");
        }
    }
}