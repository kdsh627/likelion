using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    //������ Ÿ�� enum
    //���� �����ʹ� ������ ����� (0, 1, 2)
    //�߰��� Gun = 3�̶�� Missile�� 4�� �ȴ�.
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
                Debug.Log("Ȱ �Դϴ�");
                break;
            case Weapon.Gun:
                Debug.Log("�� �Դϴ�");
                break;
            case Weapon.Missile:
                Debug.Log("�̻��� �Դϴ�");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
