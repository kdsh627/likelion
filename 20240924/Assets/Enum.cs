using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    //열거형 타입 enum
    //내부 데이터는 정수로 저장됨 (0, 1, 2)
    //중간에 Gun = 3이라면 Missile은 4가 된다.
    enum Weapon
    {
        Arrow,
        Gun,
        Missile
    }
    // Start is called before the first frame update
    void Start()
    {
        Weapon weapon = Weapon.Arrow;
        weapon = (Weapon)1;
        switch(weapon) 
        { 
            case Weapon.Arrow:
                Debug.Log("활 입니다");
                break;
            case Weapon.Gun:
                Debug.Log("총 입니다");
                break;
            case Weapon.Missile:
                Debug.Log("미사일 입니다");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
