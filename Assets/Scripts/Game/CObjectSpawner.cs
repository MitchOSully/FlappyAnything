using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectSpawner : MonoBehaviour
{
    public GameObject m_prefab;
    public float m_fSpawnDeltaTime = 3.5f;
    public float m_fVerticalOffset = 6.5f;
    public CGameManager m_gameManager; //To check if paused

    protected float m_fTimer = 0f;

    protected virtual void Update()
    {
        if (!m_gameManager.m_bPaused)
        {
            if (m_fTimer < m_fSpawnDeltaTime)
            {
                m_fTimer += Time.deltaTime;
            }
            else
            {
                Spawn();
                m_fTimer = 0;
            }
        }
    }

    protected void Spawn(float fXPos = 0)
    {
        float fLowestPoint = transform.position.y - m_fVerticalOffset;
        float fHighestPoint = transform.position.y + m_fVerticalOffset * 0.5f;

        Instantiate(m_prefab, new Vector3(transform.position.x - fXPos, Random.Range(fLowestPoint, fHighestPoint), 0), transform.rotation);
    }
}
