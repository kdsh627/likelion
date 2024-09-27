using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float Speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * Speed);

        if(transform.position.x < -10)
        {
            //this�� ���� ��ũ��Ʈ ������Ʈ�� �����ȴ�
            Destroy(gameObject); //MonoBehaviour���� �����Ѵ�. �� ��ũ��Ʈ�� �پ��ִ� gameObject�� ����
        }

    }
}
