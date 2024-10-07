using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    enum State
    {
        Playing,
        Dead
    }

    public float Speed = 5;
    public float JumpSpeed = 5;
    public Collider2D BottomCollider;
    public CompositeCollider2D TerrainCollider;

    public GameObject BulletPrefab;

    float vx = 0;
    bool grounded = true;
    float prevVx;
    float prevVy;
    State state;

    Vector2 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        state = State.Playing;
    }

    public void Restart()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        GetComponent<BoxCollider2D>().enabled = true;

        transform.eulerAngles = Vector3.zero;
        transform.position = originalPosition;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        state = State.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Dead) return;
        //Input.GetAxis("Horizontal") //이건 0, 1, -1 사이에 중간값도 있음 그래서 가속도 느낌이 있음
        //Input.GetAxisRaw("Horizontal") //애는 0, 1, -1만 있음 그래서 즉시 방향 전환
        vx = Input.GetAxisRaw("Horizontal") * Speed;
        float vy = GetComponent<Rigidbody2D>().velocity.y;

        //캐릭터가 보는 방향 전환
        if (vx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true; //왼쪽
        }
        if (vx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false; //오른쪽
        }

        //점프
        if (Input.GetButtonDown("Jump") && grounded)
        {
            vy = JumpSpeed;
        }

        //SetTrigger는 호출 시 마다 새로운 애니메이션을 작동하므로 단 한번만 작동하도록 로직을 구성해야함
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
            if (grounded) //지금은 안붙어 있는데 아까는 붙어있었음 = 점프 또는 추락
            {
                if (vy < 0) //추락 시
                {
                    GetComponent<Animator>().SetTrigger("Fall");
                }
                else //상승 시
                {   
                    GetComponent<Animator>().SetTrigger("Jump");
                }
            } 
            //아까도 안붙어 있었음 = 공중에 있음
            else
            {
                if (vy * prevVy < 0) //점프 후 추락 시에만 가능함
                {
                    GetComponent<Animator>().SetTrigger("Fall");
                }
            }
        }

        grounded = BottomCollider.IsTouching(TerrainCollider); //두 콜라이더의 접촉여부를 반환
                                                           
        prevVx = vx; //현재 프레임 vx를 이전 프레임 vx로 넘김
        prevVy = vy; //이하동문

        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy); //속도 값을 지정

        if(Input.GetButtonDown("Fire1"))
        {
            Vector2 bulletY = new Vector2(10, 0);

            if(GetComponent<SpriteRenderer>().flipX)
            {
                bulletY.x = -bulletY.x;
            }

            GameObject bullet = GameManager.Instance.ObjPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullet>().Velocity = bulletY;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }
    void Die()
    {
        state = State.Dead;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().angularVelocity = 720;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        GetComponent<BoxCollider2D>().enabled = false;

        GameManager.Instance.Die();
    }

    //private void FixedUpdate()
    //{
    //    transform.Translate(Vector2.right * vx * Time.fixedDeltaTime);
    //}
}
