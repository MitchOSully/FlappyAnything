using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDirection
{
    Left,
    Right
}

public class CAutoMove : MonoBehaviour
{
    public EDirection m_eDirection = EDirection.Left;
    public float m_fMoveSpeed = 3f;
    public float m_fDeadZone = -35f; //X coordinate at which to kill the object

    private CGameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CGameManager>();
    }

    void Update()
    {
        if (!m_gameManager.m_bPaused)
        {
            Vector3 vDirection = (m_eDirection == EDirection.Left) ? Vector3.left : Vector3.right;
            transform.position += vDirection * m_fMoveSpeed * Time.deltaTime;

            if (m_eDirection == EDirection.Left && transform.position.x < m_fDeadZone)
            {
                Destroy(gameObject);
            }
            else if (m_eDirection == EDirection.Right && transform.position.x > m_fDeadZone)
            {
                Destroy(gameObject);
            }
        }
    }
}
