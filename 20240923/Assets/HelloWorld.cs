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
        int? n = null; //�η��� Ÿ��

        Debug.Log(num1 + num2);
        Debug.Log(num1 - num2);
        Debug.Log(num1 * num2);
        Debug.Log(num1 / num2);
        Debug.Log(num1 % num2);

        Debug.Log(s1 ?? s2); //s1�� NULL�̸� s2��, �ݴ�� s1�� ��ȯ�Ѵ�.

        Debug.Log(1 + "abc"); //���� + ���ڿ��ϸ� �˾Ƽ� ���ڿ� ��ȯ

        int[] array = new int[5] { 0, 1, 2, 3, 4}; //new int[5] ��������
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        int[,] data = new int[3, 5]; //������ �迭

        int[][] data2 = new int[4][]; //�����迭 (�� �迭�� ũ�Ⱑ �ٸ� �� �ִٴ� ��)
        data2[0] = new int[2];
        data2[1] = new int[3];
        data2[2] = new int[4];
        data2[3] = new int[5]; //���� �ٽ� �ʱ�ȭ ���������

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
