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

    private float m_fDeadZone = -45f;
    private Vector3 vDirection = Vector3.zero;

    private void Start()
    {
        switch(m_eDirection)
        {
            case EDirection.Left:
            {
                vDirection = Vector3.left;
                break;
            }
            case EDirection.Right:
            {
                vDirection = Vector3.right;
                break;
            }
        }
    }

    void Update()
    {
        Vector3 vDirection = m_eDirection == EDirection.Left ? Vector3.left : Vector3.right;
        transform.position += vDirection * m_fMoveSpeed * Time.deltaTime;

        if (transform.position.x < m_fDeadZone)
        {
            Destroy(gameObject);
        }
    }
}
