using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//인터페이스는 어떠한 메소드가 있기로 했다는 약속
public interface ITurnOnable
{
    //인터페이스는 멤버 변수, 메소드 구현 안해도됨
    public void TurnOn();
    public void TurnOff();
}
