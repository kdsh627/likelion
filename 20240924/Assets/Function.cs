using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Function : MonoBehaviour
{
    //�Լ�
    void Like()
    {
        Debug.Log("���ƿ� �����ּ���");
    }

    //���ڴ� ���ʺ��� �޾ƿ��Ƿ� ����Ʈ ���� �����ʺ��� ä�����Ѵ�.
    //������ִ� ���� �����ʺ��� ��ä��� ������ ����.
    float Area(float width, float height=10)
    {
        return width * height;
    }

    //ref�� ���� �Ű������� ���簡 �ƴ� ������ �ѱ� �� ����
    //�� ���� �ٲ� �ʿ�� ����
    float AreaRef(ref float width, float height)
    {
        width = 15f;
        return width * height;
    }

    //ref�� �ٸ� ���� ���� ���� ���� ���� �� ����Ѵٴ� ��
    //�׸��� �ʱ�ȭ�� �����൵ ��
    //��� out�� �� ���� �ٲ�����Ѵ�. ���� �����ޱ� ���� ����ϴ� ���̱� ����(������ ����)
    void AreaOut(float width, float height, out float around)
    {
        around = width * height;
    }


    // Start is called before the first frame update
    void Start()    
    {
        float x = 10f;
        float y = 20f;
        float area = Area(x, y);
        float area2 = Area(height:y, width:x); //C#������ ���ڿ� �Ű������� ����� �� �ִ�.

        //ref�� ������ָ� x�� �ٲ� �� ����
        //ref�� �ʱ�ȭ�� �� ������ �Ѱ���� ��
        float area3 = AreaRef(ref x, y);

        float around;
        //out�� �ʱ�ȭ�� �ȵǾ �ѱ� �� ����
        AreaOut(x, y, out around);


        Debug.Log(area);

        Like();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
