using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public LifeDisPlayer LifeDisPlayerInstance;
    public GameObject CinamachineInstance;
    public TMP_Text timeLimitLabel;
    public float TimeLimit = 30;
    int life = 3;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Start()
    {
        life = 3;
    }
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimit -= Time.deltaTime;
        timeLimitLabel.text = "Time Left " + ((int)TimeLimit);
    }

    public void AddTime(float time)
    {
        TimeLimit += time;
    }

    public void Die()
    {
        CinamachineInstance.SetActive(false);
        life--;
        LifeDisPlayerInstance.SetLives(life);

        Invoke("Restart", 2);
    }

    void Restart()
    { 
        if(life > 0)
        {
            CinamachineInstance.SetActive(true);
            Player.Restart();
        }
        else
        {
            GameOver();
        }

        void GameOver()
        {
            Debug.Log("GameOver");
        }
    }

}
