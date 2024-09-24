using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//start�� update�� MonoBehaviour�� ��ӹ޾ƾ� �۵��Ѵ�
public class Character
{
    //�������
    public string Name;
    public int Hp;

    //������
    public Character(string name, int hp)
    {
        Name = name;
        Hp = hp;
    }


    //�޼ҵ�
    public void Hit(int damage)
    {
        Hp -= damage;
    }

    public void Heal(int heal)
    {
        Hp += heal;
    }

    public bool isAlive()
    {
        return Hp > 0;
    }

    public void Eat(Food food)
    {
        if(isAlive())
        {
            Hp += food.Hp;
        }
    }
}
