using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[][] arr = new int[4][];
        arr[0] = new int[4]{ 10, 15, 3, 2 };
        arr[1] = new int[3]{ 1, 3, 2 };
        arr[2] = new int[2]{ 5, 20 };
        arr[3] = new int[1]{ 36 };

        List<int> list = new List<int>();
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            foreach (int n in arr[i])
            {
                if (n > 10)
                {
                    list.Add(n);
                    Debug.Log(n);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
