using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTriggerMiddle : MonoBehaviour
{
    public CGameManager m_gameManager;

    void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CGameManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_gameManager.IncreaseScore(1);
        }
    }
}
