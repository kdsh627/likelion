using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPopup : MonoBehaviour
{
    [SerializeField]
    private TMP_Text resultTitle;
    [SerializeField]
    private TMP_Text scoreLabel;
    [SerializeField]
    private GameObject highScoreObject;
    [SerializeField]
    private GameObject highScorePopup;

    public void ShowHighScoresPanel()
    {
        highScorePopup.SetActive(true);
    }

    //활성화가 되면 실행(SetActive 껐다 켜도 실행)
    private void OnEnable()
    {
        Time.timeScale = 0; //1이면 1초에 1초가 흐름
        if (GameManager.Instance.IsCleard)
        {
            resultTitle.text = "Cleard!";
            scoreLabel.text = GameManager.Instance.TimeLimit.ToString("#.##"); //소수점 자리 제한
            SaveHighScore();
        }
        else
        {
            resultTitle.text = "Game Over...";
            scoreLabel.text = "";

        }

    }

    void SaveHighScore()
    {
        float score = GameManager.Instance.TimeLimit;
        float highScore = PlayerPrefs.GetFloat("hightscore", 0);

        if (score > highScore)
        {
            highScoreObject.SetActive(true);
            PlayerPrefs.SetFloat("highscore", GameManager.Instance.TimeLimit);
            PlayerPrefs.Save();
        }
        else
        {
            highScoreObject.SetActive(false);
        }

        string currentScoreString = score.ToString();
        string savedScoreString = PlayerPrefs.GetString("HighScores", "");

        if(savedScoreString == "")
        {
            PlayerPrefs.SetString("HighScores", currentScoreString);
        }
        else
        {
            string[] scoreArray = savedScoreString.Split(',');
            List<string> scoreList = new List<string>(scoreArray);

            for(int i = 0; i < scoreList.Count; i++) 
            { 
                float savedScore = float.Parse(scoreList[i]);
                if(savedScore < score) 
                {
                    scoreList.Insert(i, currentScoreString);
                    break;
                }
            }
            if(scoreArray.Length == scoreList.Count) //
            {
                scoreList.Add(currentScoreString);
            }

            if(scoreList.Count > 10)
            {
                scoreList.RemoveAt(10);
            }

            string result = string.Join(",", scoreList);
            Debug.Log(result);
            PlayerPrefs.SetString("HighScores", result);
        }

        PlayerPrefs.Save();
        
    }

    public void TryAgainPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelectScene");
    }
}
