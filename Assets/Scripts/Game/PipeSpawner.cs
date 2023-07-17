using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject m_pipeDuo;
    public float m_fSpawnRate = 3.5f;
    public float m_fPipeHeightOffset = 8f;

    private float m_fTimer = 0f;

    void Start()
    {
        float fPipeSpeed = m_pipeDuo.GetComponent<PipeMove>().m_fMoveSpeed;
        SpawnPipe(fPipeSpeed * m_fSpawnRate * 2);
        SpawnPipe(fPipeSpeed * m_fSpawnRate);
        SpawnPipe();
    }

    void Update()
    {
        if (m_fTimer < m_fSpawnRate)
        {
            m_fTimer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            m_fTimer = 0;
        }
    }

    void SpawnPipe()
    {
        SpawnPipe(0);
    }

    void SpawnPipe(float fXPos)
    {
        float fLowestPoint = transform.position.y - m_fPipeHeightOffset;
        float fHighestPoint = transform.position.y + m_fPipeHeightOffset * 0.5f;

        Instantiate(m_pipeDuo, new Vector3(transform.position.x - fXPos, Random.Range(fLowestPoint, fHighestPoint), 0), transform.rotation);
    }
}
