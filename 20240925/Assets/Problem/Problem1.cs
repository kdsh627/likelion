using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Problem1 : MonoBehaviour
{
    enum MOD
    {
        RemoveSpace,
        DistinAlpha,
    }
    // Start is called before the first frame update
    void Start()
    {
        string str1 = "  abca  ";

        string str2 = new string(str1.Reverse().ToArray());

        MOD mod = MOD.RemoveSpace;

        switch (mod)
        { 
            case MOD.RemoveSpace:
                str1.Trim();
                str2.Trim();
                break;
            case MOD.DistinAlpha:
                str1.ToUpper();
                str2.ToUpper();
                break;
        }


        if (str1 == str2)
        {
            Debug.Log("팰린드롬 이에용");
        }
        else
        {
            Debug.Log("이게 뭐에용");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
