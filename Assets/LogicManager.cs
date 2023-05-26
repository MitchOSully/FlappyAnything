using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int iScore = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public SmileyScript smiley;

    [ContextMenu("Increase Score")]
    public void IncreaseScore(int iScoreToAdd)
    {
        if (smiley.bIsAlive)
        {
            iScore += iScoreToAdd;
            scoreText.SetText(iScore.ToString());
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
