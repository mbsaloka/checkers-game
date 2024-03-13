using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject PauseScreen;
    public bool isPaused = false;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void PauseGame()
    {
        PauseScreen.SetActive(true);
        isPaused = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    // public void GameOver()
    // {
    //     gameOverScreen.SetActive(true);
    //     isGameOver = true;
    // }

    public bool GetPauseState()
    {
        return isPaused;
    }
}
