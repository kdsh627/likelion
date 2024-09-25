using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : ITurnOnable //인터페이스 상속 시 약속한 메소드를 반드시 구현해야함
{
    public void TurnOff()
    {
        Debug.Log("리모컨 버튼끄기");
    }

    public void TurnOn()
    {
        Debug.Log("리모컨 버튼켜기");
    }
}
