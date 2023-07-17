using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float m_fMoveSpeed = 3f;

    private float m_fDeadZone = -45f;

    void Update()
    {
        transform.position += Vector3.left * m_fMoveSpeed * Time.deltaTime;

        if (transform.position.x < m_fDeadZone)
        {
            Destroy(gameObject);
        }
    }
}
