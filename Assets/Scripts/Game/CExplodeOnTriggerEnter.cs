using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExplodeOnTriggerEnter : MonoBehaviour
{
    public GameObject m_explosionPrefab;
    public float m_fForceScale = 1000f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            CreateExplosion(collider);
            PushPlayer(collider.gameObject);
            Destroy(gameObject);
        }
    }

    private void CreateExplosion(Collider2D collider)
    {
        Vector2 collisionPt = collider.ClosestPoint(transform.position);
        Instantiate(m_explosionPrefab, collisionPt, Quaternion.identity);
    }

    private void PushPlayer(GameObject player)
    {
        Vector2 pushDir = player.transform.position - transform.position;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(pushDir * m_fForceScale);
    }
}
