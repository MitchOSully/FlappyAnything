using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipeDuo;
    public float fSpawnRate = 3.5f;
    public float fPipeHeightOffset = 8f;

    private float fTimer = 0f;

    void Update()
    {
        if (fTimer < fSpawnRate)
        {
            fTimer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            fTimer = 0;
        }
    }
    public void StartGame()
    {
        fTimer = 0f;
        float fPipeSpeed = pipeDuo.GetComponent<PipeMove>().fMoveSpeed;
        SpawnPipe(fPipeSpeed * fSpawnRate * 2);
        SpawnPipe(fPipeSpeed * fSpawnRate);
        SpawnPipe();
    }

    void SpawnPipe()
    {
        SpawnPipe(0);
    }

    void SpawnPipe(float fXPos)
    {
        float fLowestPoint = transform.position.y - fPipeHeightOffset;
        float fHighestPoint = transform.position.y + fPipeHeightOffset * 0.5f;

        Instantiate(pipeDuo, new Vector3(transform.position.x - fXPos, Random.Range(fLowestPoint, fHighestPoint), 0), transform.rotation);
    }
}
