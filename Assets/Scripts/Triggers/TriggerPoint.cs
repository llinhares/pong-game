using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public PlayerBase player;
    public string tagToCheck = "Ball";

    public GameObject uiEndGameMenu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == tagToCheck)
        {
            CountPoint();
        }
    }

    private void CountPoint()
    {
        player.AddPoint();
        if (!uiEndGameMenu.activeSelf) { 
            StateMachine.Instance.ResetPosition();
        }
    }
}
