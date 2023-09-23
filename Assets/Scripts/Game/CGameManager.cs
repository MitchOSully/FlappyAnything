using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    public int m_iScore = 0;
    public TextMeshProUGUI m_scoreText;
    public GameObject m_gameOverScreen;
    public TextMeshProUGUI m_highScoreText;
    public CPlayer m_player;
    public GameObject m_rocketSpawner;

    private void Start()
    {
        m_highScoreText.SetText(PlayerPrefs.GetInt("HighScore", 0).ToString());
    }

    [ContextMenu("Increase Score")]
    public void IncreaseScore(int iScoreToAdd)
    {
        if (m_player.m_bIsAlive)
        {
            m_iScore += iScoreToAdd;
            m_scoreText.SetText(m_iScore.ToString());
            
            if (UpdateHighScore())
            {
                m_highScoreText.SetText(PlayerPrefs.GetInt("HighScore", 0).ToString());
            }
        }
    }

    public void KillPlayer()
    {
        m_player.m_bIsAlive = false;
        GameOver();
    }

    public void GameOver()
    {
        m_gameOverScreen.SetActive(true);
        m_rocketSpawner.SetActive(false);
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
        if (m_iScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", m_iScore);
            bUpdated = true;
        }

        return bUpdated;
    }
}
