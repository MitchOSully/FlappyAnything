using System.Collections;
using UnityEngine;

public class CPipeSpawner : CObjectSpawner
{
    void Start()
    {
        CAutoMove scrAutoMove = m_prefab.GetComponent<CAutoMove>();
        if (scrAutoMove)
        {
            float fPipeSpeed = scrAutoMove.m_fMoveSpeed;
            Spawn(fPipeSpeed * m_fSpawnDeltaTime * 2);
            Spawn(fPipeSpeed * m_fSpawnDeltaTime);
            Spawn();
        }
    }

    public void UpdatePipeTheme()
    {
        SpriteRenderer[] pipeSpriteRenderers = m_prefab.GetComponentsInChildren<SpriteRenderer>();
        for (int ii = 0; ii < pipeSpriteRenderers.Length; ii++)
            pipeSpriteRenderers[ii].sprite = CThemeManager.CurrentPipe();
    }
}