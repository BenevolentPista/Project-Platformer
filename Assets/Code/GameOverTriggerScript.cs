using Assets.Code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTriggerScript : MonoBehaviour
{
    public LogicScript logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.KillPlayer();
    }
}
