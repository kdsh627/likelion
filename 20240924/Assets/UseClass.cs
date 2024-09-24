using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Character character = new Character("철수", 10);
        Food food1 = new Food();
        food1.Name = "Protein";
        food1.Hp = 10;

        character.Hit(5);
        character.Heal(3);
        character.Eat(food1);

        //Debug.Log(character.isAlive());


        Wizard wizard = new Wizard("영희", 10, 10);
        wizard.UseMagic();
        wizard.Hit(3);
        wizard.Heal(3);
        wizard.Hit(20);
        //Debug.Log(wizard.isAlive());


        Character tmp = wizard as Character; //Wizard 클래스가 Character의 일종이기에 이게 가능함
                                //하지만 Wizard관련 함수는 못씀
        
        Debug.Log(tmp); //캐릭터에 집어넣어도 위저드라고 출력된다.

        ((Wizard)tmp).UseMagic(); //캐릭터 클래스지만 위자드로 타입캐스팅을 하여 관련 함수를 
                                  //사용할 수 있게 한 모습

        Character char1 = new Character("누구", 10);
        
        ((Wizard)char1).UseMagic(); //코드 상으로는 에러가 없지만 실행 시 에러가 난다
                                    //타입 캐스팅이 실패하기 때문
                                    //유니티에서는 에러 발생 시 함수 실행을 중단하고 리턴한다.
        
        Debug.Log(char1 is Wizard); //캐스팅이 가능하면 true, 불가능하면 false를 리턴한다.
        Wizard wizard2 = char1 as Wizard; //좀 더 안전하게 캐스팅하는 방법
                                          //캐스팅 실패 시 NULL이 들어간다.

        //포함관계를 잘 보자.
        //상속관계에서 자식은 부모가 될 수 있지만 반대는 불가능하다.
        //고등어는 생선이라고 부를 수 있지만 생선은 고등어라고 부를 수 없다는 것
    }

    // Update is called once per frame
    void Update()
    {

    }
}
