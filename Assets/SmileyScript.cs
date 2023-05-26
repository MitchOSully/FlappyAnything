using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyScript : MonoBehaviour
{
    public Rigidbody2D smileyRigidBody;
    public float fFlapStrength = 25;
    public LogicManager logicManager;
    public bool bIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bIsAlive)
            {
                smileyRigidBody.velocity = Vector2.up * fFlapStrength;
            }
            else
            {
                logicManager.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicManager.GameOver();
        bIsAlive = false;
    }

    private void OnBecameInvisible()
    {
        logicManager.GameOver();
        bIsAlive = false;
    }
}
