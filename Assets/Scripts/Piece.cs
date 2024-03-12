using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite light_pawn, light_king;
    public Sprite dark_pawn, dark_king;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "dark_pawn":
                this.GetComponent<SpriteRenderer>().sprite = dark_pawn;
                player = "dark";
                break;
            case "dark_king":
                this.GetComponent<SpriteRenderer>().sprite = dark_king;
                player = "dark";
                break;
            case "light_pawn":
                this.GetComponent<SpriteRenderer>().sprite = light_pawn;
                player = "light";
                break;
            case "light_king":
                this.GetComponent<SpriteRenderer>().sprite = light_king;
                player = "light";
                break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.9977f;
        y *= 0.9977f;

        x += -3.49195f;
        y += -3.49195f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        Debug.Log("Clicked");
        DestroyMovePlates();
        InitiateMovePlates();
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "dark_pawn":
                PointMovePlate(1, 1);
                PointMovePlate(-1, 1);
                break;
            case "light_pawn":
                PointMovePlate(1, -1);
                PointMovePlate(-1, -1);
                break;
            case "dark_king":
            case "light_king":
                LineMovePlate(1, 1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, -1);
                break;
        }
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<Piece>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }

    public void PointMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        if (sc.PositionOnBoard(x, y))
        {
            GameObject pc = sc.GetPosition(x, y);

            if (pc == null)
            {
                MovePlateSpawn(x, y);
            }
            else if (pc.GetComponent<Piece>().player != player && sc.GetPosition(x + xIncrement, y + yIncrement) == null)
            {
                MovePlateAttackSpawn(x + xIncrement, y + yIncrement);
            }
        }
    }

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.9977f;
        y *= 0.9977f;

        x += -3.49195f;
        y += -3.49195f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.9977f;
        y *= 0.9977f;

        x += -3.49195f;
        y += -3.49195f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
}
