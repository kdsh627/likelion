using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    int stageIndex;
    public Image stageThumb;
    public TextMeshProUGUI textTitle;

    public void SetLevelInformation(int stageIndex, Sprite thumbnail, string title)
    {
        stageThumb.sprite = thumbnail;
        textTitle.text = title;
        this.stageIndex = stageIndex;
    }

    public void StageStart()
    {
        LevelManager.Instance.StartLevel(stageIndex);
    }
}
