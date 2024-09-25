using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Animal
{
    //추상클래스 : 큰 틀을 만들고 세부내용을 자식들이 구현하는 경우 사용한다
    //인스턴스화는 불가능

    public abstract void Fly(); //이름만 있는 추상 메소드

    public void introduce()
    {
        Debug.Log("안녕하세요 짐승입니다");
    }
}
