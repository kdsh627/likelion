using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, int> monster = new Dictionary<string, int>();
        monster.Add("슬라임", 5);
        monster.Add("오크", 13);
        monster.Add("고블린", 8);

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
