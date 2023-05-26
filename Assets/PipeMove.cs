using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float fMoveSpeed = 3f;

    private float fDeadZone = -45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * fMoveSpeed * Time.deltaTime;

        if (transform.position.x < fDeadZone)
        {
            Destroy(gameObject);
        }
    }
}
