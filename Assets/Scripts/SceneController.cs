using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // public GameObject gameOverScreen;
    // private bool isGameOver = false;

    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // public void restartGame()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

    // public void menu()
    // {
    //     SceneManager.LoadScene("MenuScene");
    // }

    public void quitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    // public void gameOver()
    // {
    //     gameOverScreen.SetActive(true);
    //     isGameOver = true;
    // }
}
