using System.Collections;
using UnityEngine;

public class CRocketSpawner : CObjectSpawner
{
    public int m_iFirstRocketPipe = 2; //First rocket will hit player after this pipe
                                       //Note: doesn't work when =1
    public float m_fRocketPipeOffset = 0.5f; //The fraction of the distance between two pipes to place the rocket
    public CAutoMove m_pipeMoveScript;
    public CPipeSpawner m_pipeSpawnerScript;

    private bool m_bWaiting = true;
    public float m_fStartWaitTime = 0; //Time to wait before spawning first rocket

    void Start()
    {
        m_fSpawnDeltaTime = m_pipeSpawnerScript.m_fSpawnDeltaTime;
        m_fStartWaitTime = CalculateStartWaitTime();
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

    public void UpdateRocketSkin()
    {
        SpriteRenderer rocketSpriteRenderer = m_prefab.GetComponent<SpriteRenderer>();
        if (rocketSpriteRenderer != null)
            rocketSpriteRenderer.sprite = CSkinManager.CurrentRocket();
    }

    private float CalculateStartWaitTime()
    {
        float fStartWaitTime = 0; //Return value

        CAutoMove rocketMoveScript = m_prefab.GetComponent<CAutoMove>();
        if (m_pipeMoveScript && rocketMoveScript)
        {
            float fFirstPipeTime = CalculateFirstPipeTime(m_pipeMoveScript);

            float fRocketSpeed = rocketMoveScript.m_fMoveSpeed;
            float fRocketTravelTime = transform.position.x / fRocketSpeed;

            float fOffsetTime = m_pipeSpawnerScript.m_fSpawnDeltaTime * m_fRocketPipeOffset;

            fStartWaitTime = fFirstPipeTime + m_fSpawnDeltaTime * (m_iFirstRocketPipe - 1) - fRocketTravelTime + fOffsetTime; ;
        }

        return fStartWaitTime;
    }

    //Time at which first pipe reaches player
    private float CalculateFirstPipeTime(CAutoMove pipeMoveScript)
    {
        float fPipeSpeed = pipeMoveScript.m_fMoveSpeed;
        float fPipeSpawnerPos = transform.position.x; //Assume pipe and rocket spawner at same location
        float fFirstPipeSpawnPos = fPipeSpawnerPos - fPipeSpeed * m_pipeSpawnerScript.m_fSpawnDeltaTime * 2;
        float fFirstPipeTime = fFirstPipeSpawnPos / fPipeSpeed;

        return fFirstPipeTime;
    }
}