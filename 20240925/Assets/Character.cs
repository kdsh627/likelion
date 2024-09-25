using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    //static의 경우 모든 CHaracter객체가 공유하는 값이다.
    //인스턴스 함수에서는 접근가능하다.
    static int num = 0;

    public string Name;
    protected int Hp; //상속관계에 있는 객체만 사용가능
    private int N;

    //static함수 및 변수는 객체 생성전에도 호출 가능하다.
    public static void abc()
    {
        num++;
        //Name = "응애"; <- static함수에서는 멤버변수를 부를 수 없다.
    }

    public int HP
    { 
        get { return HP; } 
        set { Hp = value; }
    }

    public void Meet(Character another)
    {
        Debug.Log(another.N); //같은 틀을 가졌으면 private변수도 불러올 수 있음
    }

    public Character()
    {

    }

    public Character(string name, int hp)
    {
        Name = name;
        Hp = hp;
        N = 5;
    }
    public void Hit(int damage, int n) //오버로드는 인자의 타입, 개수에 따라서 같은 함수명으로 사용가능하다.
    {
        Hp -= damage;
    }


    public virtual void Hit(int damage) //오버라이드(덮어쓰기)를 위해서 virtual 키워드를 써준다
    {
        Hp -= damage;
    }

    public void Heal(int heal)
    {
        if(isAlive())
        {
            Hp += heal;
        }
    }

    public bool isAlive()
    {
        return Hp > 0;
    }
}
