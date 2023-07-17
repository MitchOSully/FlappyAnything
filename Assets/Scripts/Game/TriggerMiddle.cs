using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMiddle : MonoBehaviour
{
    private const int PLAYER_LAYER = 3;
    
    public LogicManager m_logicManager;

    void Start()
    {
        m_logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PLAYER_LAYER)
        {
            m_logicManager.IncreaseScore(1);
        }
    }
}
