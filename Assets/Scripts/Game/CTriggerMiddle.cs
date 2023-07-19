using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTriggerMiddle : MonoBehaviour
{
    private const int PLAYER_LAYER = 3;
    
    public CGameManager m_gameManager;

    void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CGameManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PLAYER_LAYER)
        {
            m_gameManager.IncreaseScore(1);
        }
    }
}
