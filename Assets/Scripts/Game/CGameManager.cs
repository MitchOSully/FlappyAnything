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
    public SpriteRenderer m_playerSpriteRenderer;
    public GameObject m_rocketSpawner;
    public GameObject m_pipeSpawner;

    private void Start()
    {
        m_highScoreText.SetText(PlayerPrefs.GetInt("HighScore", 0).ToString());
        SetTheme();
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

    public void QuitToMenu()
    {
        SceneManager.LoadScene(C.SCENE_ID_START_SCREEN); 
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

    private void SetTheme()
    {
        //Player
        m_playerSpriteRenderer.sprite = CThemeManager.CurrentPlayer();

        //Pipe
        CPipeSpawner pipeSpawner = m_pipeSpawner.GetComponent<CPipeSpawner>();
        if (pipeSpawner != null)
            pipeSpawner.UpdatePipeTheme();
        
        //Rocket
        CRocketSpawner rocketSpawner = m_rocketSpawner.GetComponent<CRocketSpawner>();
        if (rocketSpawner != null)
            rocketSpawner.UpdateRocketTheme();
    }
}
