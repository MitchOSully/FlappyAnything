using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyScript : MonoBehaviour
{
    public Rigidbody2D smileyRigidBody;
    public float fFlapStrength = 25;
    public GameManager gameManager;
    public bool bIsAlive;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bIsAlive)
            {
                smileyRigidBody.velocity = Vector2.up * fFlapStrength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
        bIsAlive = false;
    }

    private void OnBecameInvisible()
    {
        gameManager.GameOver();
        bIsAlive = false;
    }
}
