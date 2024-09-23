using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class problem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //problem 1
        int a = 1;
        int b = 2;

        for(int i = 0; i < 10; i++)
        {
            Debug.Log(a);
            a *= b;
        }

        //problem 3
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Array.Reverse(arr);

        foreach(int i in arr)
        {
            Debug.Log(i);
        }

        //problem 4
        bool[,] isBig = new bool[5, 5];
        for(int i = 0; i < isBig.GetLength(0); i++)
        {
            for (int j = 0; j < isBig.GetLength(1); j++)
            {
                isBig[i, j] = i > j;
                Debug.Log(isBig[i, j]);
            }
        }

        //problem 8
        int[,] arrA = { { 1, 2 }, { 3, 4 } };
        int[,] arrB = { { 1, 2 }, { 3, 4 } };

        int[,] arrC = new int[2, 2];
        int[,] arrD = new int[2, 2];

        //행렬 합
        for (int i = 0; i < arrC.GetLength(0); i++)
        {
            for (int j = 0; j < arrC.GetLength(1); j++)
            {
                arrC[i, j] = arrA[i, j] + arrB[i, j];
                Debug.Log(arrC[i, j]);
            }
        }

        //행렬 곱
        for (int i = 0; i < arrC.GetLength(0); i++)
        {
            for (int j = 0; j < arrC.GetLength(1); j++)
            {
                for (int k = 0; k < arrC.GetLength(1); k++)
                {
                    arrD[i, j] += arrA[i, k] * arrB[k, j];
                }
                Debug.Log(arrC[i, j]);
            }
        }

        //problem 9
        int[,] arrE = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[,] arrF = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        int[,] arrG = new int[3, 3];
        int[,] arrH = new int[3, 3];

        //행렬 합
        for (int i = 0; i < arrG.GetLength(0); i++)
        {
            for (int j = 0; j < arrG.GetLength(1); j++)
            {
                arrG[i, j] = arrE[i, j] + arrF[i, j];
                Debug.Log(arrG[i, j]);
            }
        }

        //행렬 곱
        for (int i = 0; i < arrH.GetLength(0); i++)
        {
            for (int j = 0; j < arrH.GetLength(1); j++)
            {
                for (int k = 0; k < arrH.GetLength(1); k++)
                {
                    arrH[i, j] += arrE[i, k] * arrF[k, j];
                }
                Debug.Log(arrH[i, j]);
            }
        }


        //problem 10
        int[] arrSort = { 4, 5, 1, 2, 6, 3 };
        Array.Sort(arrSort);
        foreach (int i in arrSort)
        {
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
