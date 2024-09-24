using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    //List = ���Ḯ��Ʈ
    void Start()
    {
        List<string> names = new List<string>(10); //����

        names.Add("Teeno");
        names.Add("Ari");
        names.Add("������");
        names.Add("����");

        names.Remove("����"); //�����ͷ� ����
        names.RemoveAt(1); //�ε����� ����

        names.Insert(0, "�׶󰡽�"); //���ϴ� �ε����� ����

        Debug.Log(names.IndexOf("Ari")); //������ -1, ������ �ε����� ���
        Debug.Log(names.Count); //�÷��ǿ����� Length�� �ƴ� Count�� ���

        if (names.Contains("������")) //�ش� �����Ͱ� �����ϴ°� ��ȯ
        {
            Debug.Log("�ִ�");
        }

        foreach (string name in names) 
        { 
            Debug.Log(name);
        }

        //����
        Dictionary<string, string> cities = new Dictionary<string, string>();
        
        cities.Add("�ѱ�", "����");
        cities.Add("���", "�Ϲٳ�");
        cities["�ѱ�"] = "�λ�"; //�ε����� ���� �� ��ü������ Add�δ� �ߺ� �Ұ�

        Debug.Log(cities.Count);
        if(!cities.ContainsKey("�ѱ�"))
        {
            Debug.Log("�ִ�");
        }

        //������ ���
        foreach(string key in cities.Keys) 
        {
            Debug.Log(cities[key]);
        }

        foreach(KeyValuePair<string, string> pair in cities)
        {
            Debug.Log(pair.Key + " : " + pair.Value);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
