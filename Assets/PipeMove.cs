using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float fMoveSpeed = 3f;

    private float fDeadZone = -45f;

    void Update()
    {
        transform.position += Vector3.left * fMoveSpeed * Time.deltaTime;

        if (transform.position.x < fDeadZone)
        {
            Destroy(gameObject);
        }
    }
}
