using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //C#������ ���� ����� �Ұ��� ������, �������̽��� �������� ���� �� ����
        Car car = new Car();
        car.TurnOn();//CarŬ������ TurnOn ����

        ITurnOnable anObject = car;

        anObject.TurnOff();//CarŬ������ TurnOff ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
