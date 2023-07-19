using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectSpawner : MonoBehaviour
{
    public GameObject m_prefab;
    public float m_fSpawnRate = 3.5f;
    public float m_fVerticalOffset = 8f;

    private float m_fTimer = 0f;

    void Update()
    {
        if (m_fTimer < m_fSpawnRate)
        {
            m_fTimer += Time.deltaTime;
        }
        else
        {
            Spawn();
            m_fTimer = 0;
        }
    }

    protected void Spawn()
    {
        Spawn(0);
    }

    protected void Spawn(float fXPos)
    {
        float fLowestPoint = transform.position.y - m_fVerticalOffset;
        float fHighestPoint = transform.position.y + m_fVerticalOffset * 0.5f;

        Instantiate(m_prefab, new Vector3(transform.position.x - fXPos, Random.Range(fLowestPoint, fHighestPoint), 0), transform.rotation);
    }
}
