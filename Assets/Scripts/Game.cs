using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject piece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerDark = new GameObject[12];
    private GameObject[] playerLight = new GameObject[12];

    void Start()
    {
        int idx = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j += 2)
            {
                if (i % 2 == 0)
                {
                    playerLight[idx++] = Create("dark_pawn", j, i);
                    playerLight[idx] = Create("light_pawn", j + 1, i + 5);
                }
                else
                {
                    playerLight[idx++] = Create("dark_pawn", j + 1, i);
                    playerLight[idx] = Create("light_pawn", j, i + 5);
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
}
