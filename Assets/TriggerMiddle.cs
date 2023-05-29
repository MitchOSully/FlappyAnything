using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMiddle : MonoBehaviour
{
    public PlayManager playManager;

    private const int PLAYER_LAYER = 3;

    void Start()
    {
        playManager = GameObject.FindGameObjectWithTag("PlayManager").GetComponent<PlayManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PLAYER_LAYER)
        {
            playManager.IncreaseScore(1);
        }
    }
}
