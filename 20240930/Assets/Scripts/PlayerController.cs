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
    public CompositeCollider2D TerrainCollider; //

    float vx = 0;
    bool grounded = true;
    float prevVx;
    float prevVy;

    // Start is called before the first frame update
    void Start()
    {
        prevVy = GetComponent<Rigidbody2D>().velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis("Horizontal") //이건 0, 1, -1 사이에 중간값도 있음 그래서 가속도 느낌이 있음
        //Input.GetAxisRaw("Horizontal") //애는 0, 1, -1만 있음 그래서 즉시 방향 전환
        vx = Input.GetAxisRaw("Horizontal") * Speed;
        float vy = GetComponent<Rigidbody2D>().velocity.y;
        //캐릭터가 보는 방향 전환
        if (vx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (vx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //점프
        if (Input.GetButtonDown("Jump") && grounded)
        {
            vy = JumpSpeed;
        }

        //땅과 닿아있을 때
        if (BottomCollider.IsTouching(TerrainCollider))
        {
            //아까는 안붙어 있었음 = 착지
            if (!grounded)
            {
                //vx == 0이면 가만히 있다는 뜻
                if (vx == 0)
                {
                    GetComponent<Animator>().SetTrigger("Idle");
                }
                //vx != 0이면 움직이고 있다는 뜻
                else
                {
                    GetComponent<Animator>().SetTrigger("Run");
                }
            }
            //땅에 계속 붙어 있었음
            else
            {
                if (vx != prevVx) //속도가 변할 시에만 1회 작동
                {
                    if (vx == 0) //정지
                    {
                        GetComponent<Animator>().SetTrigger("Idle");
                    }
                    else //달리기
                    {
                        GetComponent<Animator>().SetTrigger("Run");
                    }
                }
            }
        }
        else
        {
            if (grounded) //지금은 안붙어 있는데 아까는 붙어있었음 = 점프
            {
                if (vy < 0)
                {
                    GetComponent<Animator>().SetTrigger("Fall");
                }
                else
                {   
                    GetComponent<Animator>().SetTrigger("Jump");
                }
            } 
            //아까도 안붙어 있었음 = 공중에 있음
            else
            {
                if (vy * prevVy < 0)
                {
                    GetComponent<Animator>().SetTrigger("Fall");
                }
            }
        }

        grounded = BottomCollider.IsTouching(TerrainCollider); //두 콜라이더의 접촉여부를 반환
        prevVx = vx;
        prevVy = vy;

        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }

    //private void FixedUpdate()
    //{
    //    transform.Translate(Vector2.right * vx * Time.fixedDeltaTime);
    //}
}
