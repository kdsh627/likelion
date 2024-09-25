using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string str1 = "   dddd     ";
        
        Debug.Log(str1.Trim()); //앞 뒤 공백 제거

        string str2 = "ABA";

        Debug.Log(str2.Replace("A", "B")); //문자열 대체

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
