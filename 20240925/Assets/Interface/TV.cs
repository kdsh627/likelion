using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : ITurnOnable //�������̽� ��� �� ����� �޼ҵ带 �ݵ�� �����ؾ���
{
    public void TurnOff()
    {
        Debug.Log("������ ��ư����");
    }

    public void TurnOn()
    {
        Debug.Log("������ ��ư�ѱ�");
    }
}
