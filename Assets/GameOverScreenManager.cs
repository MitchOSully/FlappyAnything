using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject gameOverScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        gameManager.RestartGame();
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
