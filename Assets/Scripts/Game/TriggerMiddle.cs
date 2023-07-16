using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMiddle : MonoBehaviour
{
    public LogicManager logicManager;

    private const int PLAYER_LAYER = 3;

    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PLAYER_LAYER)
        {
            logicManager.IncreaseScore(1);
        }
    }
}
