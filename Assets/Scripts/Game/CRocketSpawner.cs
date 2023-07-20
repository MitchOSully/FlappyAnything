using System.Collections;
using UnityEngine;

public class CRocketSpawner : CObjectSpawner
{
    public float m_fStartWaitTime = 0;
    public CAutoMove m_rocketMoveScript;
    public CAutoMove m_pipeMoveScript;
    public CPipeSpawner m_pipeSpawner;
    public GameObject m_pipePrefab;

    private bool m_bWaiting = true;

    void Start()
    {
        BoxCollider2D pipeBoxCollider = m_pipePrefab.GetComponentInChildren<BoxCollider2D>();
        float fPipeWidth = (pipeBoxCollider != null) ? pipeBoxCollider.size.x : 0;
        float fPipeSpeed = m_pipeMoveScript.m_fMoveSpeed;
        float fPipeSpawnDeltaTime = m_pipeSpawner.m_fSpawnDeltaTime;
        float fRocketSpeed = m_rocketMoveScript.m_fMoveSpeed;
        float fPipeGapLength = fPipeSpeed * fPipeSpawnDeltaTime - fPipeWidth;

        m_fSpawnDeltaTime = (fPipeGapLength + fPipeWidth) / fPipeSpeed;
        //m_fStartWaitTime = m_fSpawnDeltaTime - (this.transform.position.x - fPipeGapLength) / fRocketSpeed;
    }

    protected override void Update()
    {
        if (m_bWaiting)
        {
            m_fTimer += Time.deltaTime;
            m_bWaiting = (m_fTimer < m_fStartWaitTime);
        }
        else
        {
            base.Update();
        }
    }
}