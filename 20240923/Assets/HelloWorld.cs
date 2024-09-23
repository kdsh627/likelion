using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    void Start()
    {
        int num1 = 5;
        int num2 = 6;
        string s1 = "abc";
        string s2 = "def";
        int? n = null; //널러블 타입

        Debug.Log(num1 + num2);
        Debug.Log(num1 - num2);
        Debug.Log(num1 * num2);
        Debug.Log(num1 / num2);
        Debug.Log(num1 % num2);

        Debug.Log(s1 ?? s2); //s1이 NULL이면 s2를, 반대면 s1을 반환한다.

        Debug.Log(1 + "abc"); //숫자 + 문자열하면 알아서 문자열 변환

        int[] array = new int[5] { 0, 1, 2, 3, 4}; //new int[5] 생략가능
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        int[,] data = new int[3, 5]; //다차원 배열

        int[][] data2 = new int[4][]; //가변배열 (각 배열의 크기가 다를 수 있다는 뜻)
        data2[0] = new int[2];
        data2[1] = new int[3];
        data2[2] = new int[4];
        data2[3] = new int[5]; //각각 다시 초기화 시켜줘야함

        data2[1][2] = 5;

        int[] a = { 1, 2, 3 };
        foreach (int i in a)
        {
            Debug.Log(i);
        }

    }

    void Update()
    {
        
    }
}
