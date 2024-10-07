using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScorePopup : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public void OnEnable()
    {
        string[] scores = PlayerPrefs.GetString("HighScores", "").Split(',');
        string result = "";

        for(int i = 0; i < scores.Length; i++)
        {
            result += (i + 1) + ". " + scores[i] + "\n";
        }

        scoreLabel.text = result;
    }
    public void ClosePressed()
    {
        gameObject.SetActive(false);
    }
}
