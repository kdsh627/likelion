using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Wizard : Character
{
    public int Mp;

    public Wizard(string name, int hp, int mp) : base(name, hp)
    {
        Mp = mp;
    }

    public void UseMagic()
    {
        if(Mp>=5 && isAlive())
        {
            Mp -= 5;
            Debug.Log("���� ��� �л�");
        }
    }

    public override void Hit(int damage) //�������̵�
    {
        //base.Hit(damage); <-�̰� �θ��Լ��� ������

        //�̷��� Ŭ������ ���� �θ��� �Լ��� �ٸ�
        Debug.Log("���� �鿪 �Դϴ�");
    }
    //virtual�� �����ʾƵ� newŰ���带 override��� ����Ͽ� ����� ȿ���� �� �� �ִ�.
    //new�� ������ �ִ� ���� ����� ���Ӱ� �Լ��� �����Ѵٴ� ��
}
