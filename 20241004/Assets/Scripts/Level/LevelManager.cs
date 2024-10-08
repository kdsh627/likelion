using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class LevelInfo
{
    public string LevelName;
    public Sprite LevelThumb;
    public GameObject LevelPrefab;
}

public class LevelManager : MonoBehaviour
{
    public GameObject SelectedPrefab;
    public List<LevelInfo> Levels;

    private static LevelManager instance;
    public static LevelManager Instance
    { 
        get { return instance; }
        private set { instance = value; }
    }

    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //씬을 이동해도 죽지 않음
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartLevel(int index)
    {
        SelectedPrefab = Levels[index].LevelPrefab;
        SceneManager.LoadScene("GameScene");
    }
}
