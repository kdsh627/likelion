using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Function : MonoBehaviour
{
    //함수
    void Like()
    {
        Debug.Log("좋아요 눌러주세요");
    }

    //인자는 왼쪽부터 받아오므로 디폴트 값은 오른쪽부터 채워야한다.
    //명시해주던 말던 오른쪽부터 안채우면 오류가 난다.
    float Area(float width, float height=10)
    {
        return width * height;
    }

    //ref를 통해 매개변수를 복사가 아닌 참조로 넘길 수 있음
    //꼭 값을 바꿀 필요는 없음
    float AreaRef(ref float width, float height)
    {
        width = 15f;
        return width * height;
    }

    //ref와 다른 점은 여러 리턴 값을 받을 때 사용한다는 점
    //그리고 초기화를 안해줘도 됨
    //대신 out은 꼭 값을 바꿔줘야한다. 값을 돌려받기 위해 사용하는 것이기 때문(리턴의 개념)
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
        float area2 = Area(height:y, width:x); //C#에서는 인자와 매개변수를 명시할 수 있다.

        //ref를 명시해주면 x는 바꿀 수 있음
        //ref는 초기화가 된 변수를 넘겨줘야 함
        float area3 = AreaRef(ref x, y);

        float around;
        //out은 초기화가 안되어도 넘길 수 있음
        AreaOut(x, y, out around);


        Debug.Log(area);

        Like();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
