using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    public int Mp;
    
    public Wizard(string name, int hp, int mp) : base(name, hp)//부모의 생성자를 가져다 쓴다는 뜻
    {
        Mp = mp;
    }

    public void UseMagic()
    {
        if(Mp >= 5)
        {
            Mp -= 5;
            Debug.Log("마법 뿅뿅");
        }
    }
}
