using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    public Rigidbody2D m_rigidBody;
    public float m_fFlapStrength = 25;
    public CGameManager m_gameManager;

    [System.NonSerialized]
    public bool m_bIsAlive = true;

    private float m_fGravityScaleBackup;
    private Vector2 m_velocityBackup;

    private void Start()
    {
        m_fGravityScaleBackup = m_rigidBody.gravityScale;
    }

    void Update()
    {
        if (m_bIsAlive)
        {
            if (!m_gameManager.m_bPaused)
            {
                //Normal behaviour
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    m_rigidBody.velocity = Vector2.up * m_fFlapStrength;
                }
            }
            else
            {
                //Paused behaviour
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_gameManager.ResumeGame();
                }
            }
        }
        else
        {
            //Game over behaviour
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_gameManager.RestartGame();
            }
        }
    }

    private void OnBecameInvisible()
    {
        m_gameManager.KillPlayer(); 
    }

    public void DisableGravity()
    {
        m_rigidBody.gravityScale = 0f;
        m_velocityBackup = m_rigidBody.velocity;
        m_rigidBody.velocity = Vector2.zero;
    }

    public void EnableGravity()
    {
        m_rigidBody.gravityScale = m_fGravityScaleBackup;
        m_rigidBody.velocity = m_velocityBackup;
    }
}
