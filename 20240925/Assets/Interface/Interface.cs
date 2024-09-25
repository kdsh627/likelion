using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //C#에서는 다중 상속이 불가능 하지만, 인터페이스는 다중으로 받을 수 있음
        Car car = new Car();
        car.TurnOn();//Car클래스의 TurnOn 실행

        ITurnOnable anObject = car;

        anObject.TurnOff();//Car클래스의 TurnOff 실행
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
