using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyScript : MonoBehaviour
{
    public Rigidbody2D m_smileyRigidBody;
    public float m_fFlapStrength = 25;
    public LogicManager m_logicManager;
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
                m_logicManager.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_logicManager.GameOver();
        m_bIsAlive = false;
    }

    private void OnBecameInvisible()
    {
        m_logicManager.GameOver();
        m_bIsAlive = false;
    }
}
