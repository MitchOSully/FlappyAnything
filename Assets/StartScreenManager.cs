using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject startScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameManager.StartGame();
    }
}
