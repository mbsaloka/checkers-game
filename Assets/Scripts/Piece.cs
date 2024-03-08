using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    public Sprite light_pawn, light_king;
    public Sprite dark_pawn, dark_king;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "dark_pawn": this.GetComponent<SpriteRenderer>().sprite = dark_pawn; break;
            case "dark_king": this.GetComponent<SpriteRenderer>().sprite = dark_king; break;
            case "light_pawn": this.GetComponent<SpriteRenderer>().sprite = light_pawn; break;
            case "light_king": this.GetComponent<SpriteRenderer>().sprite = light_king; break;
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
}
