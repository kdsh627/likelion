using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Problem5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> list = new List<int>();

        int i = 1;
        int result = 0;
        while (true)
        {
            string s = Convert.ToString(i, 2);
            string tmp = "";

            foreach (char c in s)
            {
                if (c == '0')
                {
                    tmp += c;
                }
                else
                {
                    tmp += '5';
                }
            }

            result = Int32.Parse(tmp);
            if (result > 1000) break;
            Debug.Log(result);
            list.Add(result);

            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
