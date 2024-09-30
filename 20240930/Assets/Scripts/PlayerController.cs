using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5;
    public float JumpSpeed = 5;

    float vx = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis("Horizontal") //�̰� 0, 1, -1 ���̿� �߰����� ���� �׷��� ���ӵ� ������ ����
        //Input.GetAxisRaw("Horizontal") //�ִ� 0, 1, -1�� ���� �׷��� ��� ���� ��ȯ
        vx = Input.GetAxisRaw("Horizontal") * Speed;
        float vy = GetComponent<Rigidbody2D>().velocity.y;
        //ĳ���Ͱ� ���� ���� ��ȯ
        if (vx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (vx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //����
        if(Input.GetButtonDown("Jump"))
        {
            vy = JumpSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2 (vx,vy);
    }

    //private void FixedUpdate()
    //{
    //    transform.Translate(Vector2.right * vx * Time.fixedDeltaTime);
    //}
}
