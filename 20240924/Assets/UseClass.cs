using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Character character = new Character("ö��", 10);
        Food food1 = new Food();
        food1.Name = "Protein";
        food1.Hp = 10;

        character.Hit(5);
        character.Heal(3);
        character.Eat(food1);

        //Debug.Log(character.isAlive());


        Wizard wizard = new Wizard("����", 10, 10);
        wizard.UseMagic();
        wizard.Hit(3);
        wizard.Heal(3);
        wizard.Hit(20);
        //Debug.Log(wizard.isAlive());


        Character tmp = wizard as Character; //Wizard Ŭ������ Character�� �����̱⿡ �̰� ������
                                //������ Wizard���� �Լ��� ����
        
        Debug.Log(tmp); //ĳ���Ϳ� ����־ �������� ��µȴ�.

        ((Wizard)tmp).UseMagic(); //ĳ���� Ŭ�������� ���ڵ�� Ÿ��ĳ������ �Ͽ� ���� �Լ��� 
                                  //����� �� �ְ� �� ���

        Character char1 = new Character("����", 10);
        
        ((Wizard)char1).UseMagic(); //�ڵ� �����δ� ������ ������ ���� �� ������ ����
                                    //Ÿ�� ĳ������ �����ϱ� ����
                                    //����Ƽ������ ���� �߻� �� �Լ� ������ �ߴ��ϰ� �����Ѵ�.
        
        Debug.Log(char1 is Wizard); //ĳ������ �����ϸ� true, �Ұ����ϸ� false�� �����Ѵ�.
        Wizard wizard2 = char1 as Wizard; //�� �� �����ϰ� ĳ�����ϴ� ���
                                          //ĳ���� ���� �� NULL�� ����.

        //���԰��踦 �� ����.
        //��Ӱ��迡�� �ڽ��� �θ� �� �� ������ �ݴ�� �Ұ����ϴ�.
        //����� �����̶�� �θ� �� ������ ������ ������ �θ� �� ���ٴ� ��
    }

    // Update is called once per frame
    void Update()
    {

    }
}
