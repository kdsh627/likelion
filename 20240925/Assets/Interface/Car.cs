using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : ITurnOnable
{
    public void TurnOff()
    {
        Debug.Log("�� Ű�� �־�");
    }

    public void TurnOn()
    {
        Debug.Log("�� Ű�� ����");
    }
}
