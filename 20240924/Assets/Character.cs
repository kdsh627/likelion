using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//start나 update는 MonoBehaviour를 상속받아야 작동한다
public class Character
{
    //멤버변수
    public string Name;
    public int Hp;

    //생성자
    public Character(string name, int hp)
    {
        Name = name;
        Hp = hp;
    }


    //메소드
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
