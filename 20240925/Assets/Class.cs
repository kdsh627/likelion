using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Character charles = new Character("철수", 10);

        charles.HP = 10; //setter
        Debug.Log(charles.HP); //getter

        Wizard wiz = new Wizard("법사", 10, 5);
        wiz.Hit(5); //오버라이드된 함수 실행

        Character minsoo = wiz as Character;
        minsoo.Hit(5);//이래도 오버라이드된 함수 실행 
                      //하지만 new를 사용시 그냥 Character클래스 함수 사용
                      //new는 타입을 보고 virtual은 본질을 본다

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
