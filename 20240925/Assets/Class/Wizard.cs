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
            Debug.Log("마법 사용 뿅뿅");
        }
    }

    public override void Hit(int damage) //오버라이드
    {
        //base.Hit(damage); <-이건 부모함수도 실행함

        //이러면 클래스에 따라서 부르는 함수가 다름
        Debug.Log("물리 면역 입니다");
    }
    //virtual을 쓰지않아도 new키워드를 override대신 사용하여 비슷한 효과를 낼 수 있다.
    //new는 기존에 있던 것을 지우고 새롭게 함수를 정의한다는 뜻
}
