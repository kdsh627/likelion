using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    //static�� ��� ��� CHaracter��ü�� �����ϴ� ���̴�.
    //�ν��Ͻ� �Լ������� ���ٰ����ϴ�.
    static int num = 0;

    public string Name;
    protected int Hp; //��Ӱ��迡 �ִ� ��ü�� ��밡��
    private int N;

    //static�Լ� �� ������ ��ü ���������� ȣ�� �����ϴ�.
    public static void abc()
    {
        num++;
        //Name = "����"; <- static�Լ������� ��������� �θ� �� ����.
    }

    public int HP
    { 
        get { return HP; } 
        set { Hp = value; }
    }

    public void Meet(Character another)
    {
        Debug.Log(another.N); //���� Ʋ�� �������� private������ �ҷ��� �� ����
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
    public void Hit(int damage, int n) //�����ε�� ������ Ÿ��, ������ ���� ���� �Լ������� ��밡���ϴ�.
    {
        Hp -= damage;
    }


    public virtual void Hit(int damage) //�������̵�(�����)�� ���ؼ� virtual Ű���带 ���ش�
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
