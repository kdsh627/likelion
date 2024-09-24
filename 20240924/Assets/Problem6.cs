using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, int> monster = new Dictionary<string, int>();
        monster.Add("������", 5);
        monster.Add("��ũ", 13);
        monster.Add("���", 8);

        float experAve = 0;
        foreach(KeyValuePair<string, int> pair in monster)
        {
            experAve += pair.Value;
        }

        Debug.Log(experAve / monster.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
