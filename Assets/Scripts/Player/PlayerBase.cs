using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerBase : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 10;
    public Image uiImage;
    public string playerName;

    [Header("Key Setup")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    [Header("Player Settings")]
    public string tmpPlayerName;
    public string keyPlayerId;
    public string keyPlayerPoints;

    private void Awake()
    {
        ResetPoints();
        CheckIfNameExist();
    }
    public void SetName(string name, bool reload)
    {
        PlayerPrefs.SetString(keyPlayerId, name);
        playerName = PlayerPrefs.GetString(keyPlayerId);
        if(reload) SceneManager.LoadScene(0);
    }
    public void CheckIfNameExist()
    {
        if (PlayerPrefs.GetString(keyPlayerId) == "")
        {
            SetName(tmpPlayerName, true);
        }
    }
    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }
    public void ResetPoints()
    {
        currentPoints = 0;
        UpdateUi();
    }
    void Update()
    {
        if (Input.GetKey(keyCodeMoveUp))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
        } else if (Input.GetKey(keyCodeMoveDown))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed * -1);
        }
    }
    public void AddPoint()
    {
        currentPoints++;
        PlayerPrefs.SetInt(keyPlayerPoints, currentPoints);
        UpdateUi();
        CheckMaxPoints();
    }

    private void UpdateUi()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighScoreManager.Instance.SavePlayerWinner(this);
        }
    }

    public void ChangeColor(Color color)
    {
        uiImage.color = color;
    }
}
