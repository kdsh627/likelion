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
