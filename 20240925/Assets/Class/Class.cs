using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Character charles = new Character("ö��", 10);

        charles.HP = 10; //setter
        Debug.Log(charles.HP); //getter

        Wizard wiz = new Wizard("����", 10, 5);
        wiz.Hit(5); //�������̵�� �Լ� ����

        Character minsoo = wiz as Character;
        minsoo.Hit(5);//�̷��� �������̵�� �Լ� ���� 
                      //������ new�� ���� �׳� CharacterŬ���� �Լ� ���
                      //new�� Ÿ���� ���� virtual�� ������ ����

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
