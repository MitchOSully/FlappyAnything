using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKillPlayerOnTriggerEnter : MonoBehaviour
{
    private CGameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            m_gameManager.KillPlayer();
        }
    }
}
