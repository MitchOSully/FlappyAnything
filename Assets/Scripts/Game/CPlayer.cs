using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    public Rigidbody2D m_rigidBody;
    public float m_fFlapStrength = 25;
    public CGameManager m_gameManager;
    public bool m_bIsAlive = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_bIsAlive)
            {
                m_rigidBody.velocity = Vector2.up * m_fFlapStrength;
            }
            else
            {
                m_gameManager.RestartGame();
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    m_gameManager.KillPlayer();
    //}

    private void OnBecameInvisible()
    {
        m_gameManager.KillPlayer(); 
    }
}
