using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, string> KoEn = new Dictionary<string, string>();
        KoEn.Add("���", "apple");
        KoEn.Add("�ٳ���", "banana");
        KoEn.Add("������", "Orange");
        KoEn.Add("���콺", "mouse");
        KoEn.Add("����", "hole");

        Dictionary<string, string> EnKo = new Dictionary<string, string>();
        foreach (KeyValuePair<string, string> pair in KoEn)
        {
            EnKo.Add(pair.Value, pair.Key);
            Debug.Log(pair.Value + " : " + pair.Key);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
