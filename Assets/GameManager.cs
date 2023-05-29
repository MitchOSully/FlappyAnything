using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public StartScreenManager startScreenManager;
    public PlayManager playManager;
    public GameOverScreenManager gameOverScreenManager;

    public GameObject scoreText;
    public GameObject startScreen;
    public SmileyScript smiley;

    private const float GRAVITY_SCALE = 8.66f;

    private void Start()
    {
        startScreen.SetActive(true);

        smiley.bIsAlive = false;
        smiley.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    public void StartGame()
    {
        startScreenManager.gameObject.SetActive(false);

        smiley.bIsAlive = true;
        smiley.GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
        scoreText.SetActive(true);

        playManager.gameObject.SetActive(true);
        playManager.StartGame();
    }

    public void GameOver()
    {
        playManager.gameObject.SetActive(false);

        gameOverScreenManager.gameObject.SetActive(true);
        gameOverScreenManager.GameOver();
    }

    public void RestartGame()
    {
        gameOverScreenManager.gameObject.SetActive(false);

        GameObject[] allPipes = GameObject.FindGameObjectsWithTag("PipeDuo");
        foreach (GameObject pipe in allPipes)
        {
            Destroy(pipe);
        }
        smiley.transform.position = Vector3.zero;
        smiley.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        smiley.transform.rotation = Quaternion.identity;
        smiley.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;

        startScreenManager.gameObject.SetActive(true);
        startScreenManager.StartGame();
    }
}
