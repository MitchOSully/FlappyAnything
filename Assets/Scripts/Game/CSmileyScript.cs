using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSmileyScript : MonoBehaviour
{
    public Rigidbody2D m_smileyRigidBody;
    public float m_fFlapStrength = 25;
    public CGameManager m_gameManager;
    public bool m_bIsAlive = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_bIsAlive)
            {
                m_smileyRigidBody.velocity = Vector2.up * m_fFlapStrength;
            }
            else
            {
                m_gameManager.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_gameManager.GameOver();
        m_bIsAlive = false;
    }

    private void OnBecameInvisible()
    {
        m_gameManager.GameOver();
        m_bIsAlive = false;
    }
}
