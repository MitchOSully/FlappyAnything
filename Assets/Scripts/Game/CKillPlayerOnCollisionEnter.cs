using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKillPlayerOnCollisionEnter : MonoBehaviour
{
    private CGameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CGameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_gameManager.KillPlayer();
        }
    }
}
