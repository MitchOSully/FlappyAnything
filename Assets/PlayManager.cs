using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayManager : MonoBehaviour
{
    public SmileyScript smiley;
    public PipeSpawner pipeSpawner;
    public int iScore = 0;
    public TextMeshProUGUI scoreText;

    public void StartGame()
    {
        iScore = 0;
        scoreText.SetText(iScore.ToString());

        pipeSpawner.gameObject.SetActive(true);
        pipeSpawner.StartGame();
    }

    [ContextMenu("Increase Score")]
    public void IncreaseScore(int iScoreToAdd)
    {
        if (smiley.bIsAlive)
        {
            iScore += iScoreToAdd;
            scoreText.SetText(iScore.ToString());
        }
    }
}
