using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    //List = 연결리스트
    void Start()
    {
        List<string> names = new List<string>(10); //선언

        names.Add("Teeno");
        names.Add("Ari");
        names.Add("스웨인");
        names.Add("제드");

        names.Remove("제드"); //데이터로 제거
        names.RemoveAt(1); //인덱스로 제거

        names.Insert(0, "그라가스"); //원하는 인덱스에 삽입

        Debug.Log(names.IndexOf("Ari")); //없으면 -1, 있으면 인덱스가 출력
        Debug.Log(names.Count); //컬렉션에서는 Length가 아닌 Count를 사용

        if (names.Contains("스웨인")) //해당 데이터가 존재하는가 반환
        {
            Debug.Log("있다");
        }

        foreach (string name in names) 
        { 
            Debug.Log(name);
        }

        //선언
        Dictionary<string, string> cities = new Dictionary<string, string>();
        
        cities.Add("한국", "서울");
        cities.Add("쿠바", "하바나");
        cities["한국"] = "부산"; //인덱스로 접근 시 대체되지만 Add로는 중복 불가

        Debug.Log(cities.Count);
        if(!cities.ContainsKey("한국"))
        {
            Debug.Log("있다");
        }

        //꺼내는 방식
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
