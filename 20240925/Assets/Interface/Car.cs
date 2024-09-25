using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : ITurnOnable
{
    public void TurnOff()
    {
        Debug.Log("차 키를 넣어");
    }

    public void TurnOn()
    {
        Debug.Log("차 키를 돌려");
    }
}
