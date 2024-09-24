using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem11 : MonoBehaviour
{
    struct Character
    {
        public string name;
        public int attack;

        public Character(string name, int attack)
        {
            this.name = name;
            this.attack = attack;
        }
    }
    void Start()
    {
        List<Character> list = new List<Character>();
        list.Add(new Character("�μ�", 12));
        list.Add(new Character("ö��", 15));

        int count = 0;
        float attackAve = 0;
        foreach (Character c in list) 
        { 
            if(c.name.Contains("��"))
            {
                attackAve += c.attack;
                count++;
            }
        }

        Debug.Log(attackAve / count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
