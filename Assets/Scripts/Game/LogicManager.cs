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
    public TextMeshProUGUI highScoreText;
    public SmileyScript smiley;

    private void Start()
    {
        highScoreText.SetText(PlayerPrefs.GetInt("HighScore", 0).ToString());
    }

    [ContextMenu("Increase Score")]
    public void IncreaseScore(int iScoreToAdd)
    {
        if (smiley.bIsAlive)
        {
            iScore += iScoreToAdd;
            scoreText.SetText(iScore.ToString());
            
            if (UpdateHighScore())
            {
                highScoreText.SetText(PlayerPrefs.GetInt("HighScore", 0).ToString());
            }
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

    private bool UpdateHighScore()
    {
        bool bUpdated = false;
        if (iScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", iScore);
            bUpdated = true;
        }

        return bUpdated;
    }
}
