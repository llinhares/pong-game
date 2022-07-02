using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    public StateMachine stateMachine;

    public static GameManager Instance;

    public float timeToSetBallFree = 1f;

    public List<PlayerBase> players;
    public string KeyToCheck = "Player";

    [Header("Menus")]
    public GameObject uiMainMenu;
    public GameObject uiEndGameMenu;

    private void Awake()
    {
        Instance = this;
    }
    public void SwitchStateReset()
    {
        stateMachine.ResetPosition();
    }

    public void ResetBallPosition()
    {
        ballBase.CanMove(false);
        ballBase.ResetBallPosition();

        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void ResetPlayers()
    {
        foreach(var player in players)
        {
            player.ResetPoints();
        }
    }
    public void CheckPlayerNames()
    {
        foreach (var player in players)
        {
            player.CheckIfNameExist();
        }
    }

    public void StartGame()
    {
        ballBase.CanMove(true);
    }

    public void EndGame()
    {
        stateMachine.SwithToEndGame();
    }
    public void ShowMainMenu()
    {
        ballBase.CanMove(false);
        uiMainMenu.SetActive(true);
    }
    public void ShowEndGameMenu()
    {
        ballBase.CanMove(false);
        ballBase.ResetBallPosition();
        uiEndGameMenu.SetActive(true);
    }
}
