using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject LevelPanelPrefab;
    public GameObject ScrollViewContent;

    private void Start()
    {
        for(int i = 0; i < LevelManager.Instance.Levels.Count; i++)
        {
            LevelInfo info = LevelManager.Instance.Levels[i]; 
            GameObject go = Instantiate(LevelPanelPrefab, ScrollViewContent.transform);
            go.GetComponent<LevelPanel>().SetLevelInformation(i, info.LevelThumb, info.LevelName);
        }
    }
}
