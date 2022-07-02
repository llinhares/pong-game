using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    public string keyToSave = "keyHighScore";

    [Header("References")]
    public TextMeshProUGUI uiTextHighScore;
    public TextMeshProUGUI uiTextHighScoreEndGame;
    public TextMeshProUGUI uiTextHighScoreFullResult;
    public List<PlayerBase> players;

    private void Awake()
    {
        Instance = this;
    }
    public void OnEnable()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        uiTextHighScore.text = PlayerPrefs.GetString(keyToSave, "Sem pontuação.");
        uiTextHighScoreEndGame.text = PlayerPrefs.GetString(keyToSave, "Sem vencedor.");

        int i = 0;
        uiTextHighScoreFullResult.text = "";
        foreach (var player in players)
        {
            if (i > 0)
            {
                uiTextHighScoreFullResult.text += " x " + PlayerPrefs.GetString(player.keyPlayerId) + " (" + PlayerPrefs.GetInt(player.keyPlayerPoints) + ")";
            }
            else
            {
                uiTextHighScoreFullResult.text += PlayerPrefs.GetString(player.keyPlayerId) + " (" + PlayerPrefs.GetInt(player.keyPlayerPoints) + ")";
            }
            i++;
        }
    }
    public void SavePlayerWinner(PlayerBase player)
    {
        var playerName = PlayerPrefs.GetString(player.keyPlayerId, "Sem vencedor.");
        PlayerPrefs.SetString(keyToSave, playerName);
        UpdateText();
    }
}
