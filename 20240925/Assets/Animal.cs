using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Animal
{
    //�߻�Ŭ���� : ū Ʋ�� ����� ���γ����� �ڽĵ��� �����ϴ� ��� ����Ѵ�
    //�ν��Ͻ�ȭ�� �Ұ���

    public abstract void Fly(); //�̸��� �ִ� �߻� �޼ҵ�

    public void introduce()
    {
        Debug.Log("�ȳ��ϼ��� �����Դϴ�");
    }
}
