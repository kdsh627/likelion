using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    public int Mp;
    
    public Wizard(string name, int hp, int mp) : base(name, hp)//�θ��� �����ڸ� ������ ���ٴ� ��
    {
        Mp = mp;
    }

    public void UseMagic()
    {
        if(Mp >= 5)
        {
            Mp -= 5;
            Debug.Log("���� �л�");
        }
    }
}
