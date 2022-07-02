using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeNameBase : MonoBehaviour
{
    public string tmpName;
    [Header("References")]

    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changeNameInput;
    public PlayerBase player;

    private string playerName;
    private void Awake()
    {
        uiTextName.text = PlayerPrefs.GetString(player.keyPlayerId);
    }
    public void ChangeName()
    {
        playerName = uiInputField.text;
        uiTextName.text = playerName;
        changeNameInput.SetActive(false);
        player.SetName(playerName, false);
    }
}
