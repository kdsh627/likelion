using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string str1 = "   dddd     ";
        
        Debug.Log(str1.Trim()); //�� �� ���� ����

        string str2 = "ABA";

        Debug.Log(str2.Replace("A", "B")); //���ڿ� ��ü

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
