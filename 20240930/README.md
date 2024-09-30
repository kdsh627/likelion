# 2024-09-30 유니티 학습

## 플랫포머 게임 제작

- 불러온 스프라이트 이미지에서 모드를 Multiple로 해주자

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/39ef21d3-82db-439c-afe0-05fd47b6e74f/image.png)

- 이제 에디터를 켜서 슬라이스 ⇒  타입 설정 ⇒ 16, 16으로 해준다.

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/c027aeda-8abb-4e67-905e-2cc6bdc3bc1e/image.png)

- Rectangular를 선택하여 Grid를 생성할 수 있다.

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/9b7dc721-3def-4ec7-a1ac-3ef5e84ba4d7/image.png)

- Open TilePalette를 통해 레벨 디자인이 가능해진다. 땅이랑 풀 같은 건 다른 터레인으로 분리시켜놓는다. 또한, 타일 사이즈가 맞지 않으면 Grid에서 셀 사이즈를 만져보자

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/91877d8c-80a4-41dc-8b8a-a8cb72d090d6/image.png)

- 땅에는 이 3개를 추가해준다 (Used By Composite 체크 하면 그리드마다 적용되었던 맵 콜라이더가 합쳐진다.)그리고 맵이 바뀌는 일도 없으니 Body는 스태틱으로 해준다.

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/1bafa2c6-0b42-48f8-aa2c-48619d254095/image.png)

- 플레이어의 경우 리지드바디의 Freeze Rotation에 체크해준다. Z축으로의 회전을 막아서 캐릭터가 앞 뒤로 넘어지는 것을 방지한다.

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/f0c89e3e-f87a-44d2-a58c-fdf2f4414413/image.png)

- 시네머신을 패키지 매니저에서 추가하고 Virtual Camera하나를 생성한다. Follow에 플레이어를 넣어주면 따라다닌다.

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/34854741-2cfb-4f2f-8e28-c0e1a67c0e09/image.png)

- 그리고 빈 오브젝트 생성 후 Polygon Colider 2D를 추가하고 사각형으로 맵을 채운다. 그 뒤로 Virtual Camera에서 Add Extension 에서 Cinemachine Confiner 2D를 선택하여 방금 생성한 오브젝트를 넣어준다. 이러면 팔로우 카메라가 지정한 영역 밖으로 나가지 않는다.

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/3a7bfb2a-3315-4e59-8fd2-9399f124b5ff/image.png)

- 애니메이터는 이렇게 구성된다 기본 설정에서 Transition Duration을 0으로 바꿔줬다. 트리거는 필요한 만큼 생성하고 지정해주자

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/579118ca-e1ae-4c92-b8ec-36d637c76e35/7dcfcd90-185e-4d08-aa46-853d6c39a42e/image.png)

- 다음은 플레이어 코드이다.

```csharp
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5;
    public float JumpSpeed = 5;
    public Collider2D BottomCollider; //플레이어 발에 달아놓은 콜라이더
    public CompositeCollider2D TerrainCollider; //맵을 구성하는 터레인 콜라이더

    float vx = 0;
    bool grounded = true; //땅에 닿았는가
    float prevVx;
    float prevVy;

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
    }

    //private void FixedUpdate()
    //{
    //    transform.Translate(Vector2.right * vx * Time.fixedDeltaTime);
    //}
}

```
