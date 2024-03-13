using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    public GameObject sceneController;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    int attackedX;
    int attackedY;

    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
        if (!sceneController.GetComponent<SceneController>().isPaused)
        {

            controller = GameObject.FindGameObjectWithTag("GameController");

            if (attack)
            {
                GameObject pc = controller.GetComponent<Game>().GetPosition(attackedX, attackedY);
                controller.GetComponent<Game>().SetPositionEmpty(attackedX, attackedY);
                Destroy(pc);
            }

            controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Piece>().GetXBoard(), reference.GetComponent<Piece>().GetYBoard());

            reference.GetComponent<Piece>().SetXBoard(matrixX);
            reference.GetComponent<Piece>().SetYBoard(matrixY);
            reference.GetComponent<Piece>().SetCoords();

            controller.GetComponent<Game>().SetPosition(reference);

            controller.GetComponent<Game>().NextTurn();

            reference.GetComponent<Piece>().DestroyMovePlates();
        }
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetAttackedCoords(int x, int y)
    {
        attackedX = x;
        attackedY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
