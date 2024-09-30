using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5;
    public float JumpSpeed = 5;
    public Collider2D BottomCollider;
    public CompositeCollider2D TerrainCollider;

    float vx = 0;
    bool grounded = true;
    float prevVx;
    float prevVy;

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
            GetComponent<SpriteRenderer>().flipX = true; //����
        }
        if (vx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false; //������
        }

        //����
        if (Input.GetButtonDown("Jump") && grounded)
        {
            vy = JumpSpeed;
        }

        //SetTrigger�� ȣ�� �� ���� ���ο� �ִϸ��̼��� �۵��ϹǷ� �� �ѹ��� �۵��ϵ��� ������ �����ؾ���
        //���� ������� ��
        if (BottomCollider.IsTouching(TerrainCollider))
        {
            //�Ʊ�� �Ⱥپ� �־��� = ����
            if (!grounded)
            {
                //vx == 0�̸� ������ �ִٴ� ��
                if (vx == 0)
                {
                    GetComponent<Animator>().SetTrigger("Idle");
                }
                //vx != 0�̸� �����̰� �ִٴ� ��
                else
                {
                    GetComponent<Animator>().SetTrigger("Run");
                }
            }
            //���� ��� �پ� �־���
            else
            {
                if (vx != prevVx) //�ӵ��� ���� �ÿ��� 1ȸ �۵�
                {
                    if (vx == 0) //����
                    {
                        GetComponent<Animator>().SetTrigger("Idle");
                    }
                    else //�޸���
                    {
                        GetComponent<Animator>().SetTrigger("Run");
                    }
                }
            }
        }
        else
        {
            if (grounded) //������ �Ⱥپ� �ִµ� �Ʊ�� �پ��־��� = ���� �Ǵ� �߶�
            {
                if (vy < 0) //�߶� ��
                {
                    GetComponent<Animator>().SetTrigger("Fall");
                }
                else //��� ��
                {   
                    GetComponent<Animator>().SetTrigger("Jump");
                }
            } 
            //�Ʊ �Ⱥپ� �־��� = ���߿� ����
            else
            {
                if (vy * prevVy < 0) //���� �� �߶� �ÿ��� ������
                {
                    GetComponent<Animator>().SetTrigger("Fall");
                }
            }
        }

        grounded = BottomCollider.IsTouching(TerrainCollider); //�� �ݶ��̴��� ���˿��θ� ��ȯ
        prevVx = vx; //���� ������ vx�� ���� ������ vx�� �ѱ�
        prevVy = vy; //���ϵ���

        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy); //�ӵ� ���� ����
    }

    //private void FixedUpdate()
    //{
    //    transform.Translate(Vector2.right * vx * Time.fixedDeltaTime);
    //}
}
