using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float terminalSpeed = 20f; //종단속도, 유체역학에서 물체의 속도가 외부의 다른힘과 동등해지면 속도가 일정해짐
    public float gravity = 9.8f;
    public float jumpSpeed = 10f;
    public Animator animator;
    public Weapon weapon;

    bool isGrounded;
    float groundedTimer;
    float verticalSpeed;
    float horizontalAngle;
    float verticalAngle;

    public float WalkingSpeed = 7;
    public float mouseSens = 1;
    public Transform CameraTransform;

    InputAction moveAction;
    InputAction lookAction;
    InputAction fireAction;
    InputAction reloadAction;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked; // 마우스를 게임 중앙 좌표에 고정시키고 마우스커서가 안보임

        InputActionAsset inputActions = GetComponent<PlayerInput>().actions; //플레이어 인풋의 액션을 받아온다.

        moveAction = inputActions.FindAction("Move"); //Move를 따로 분리
        lookAction = inputActions.FindAction("Look"); //LooK을 따로 분리
        fireAction = inputActions.FindAction("Fire");
        reloadAction = inputActions.FindAction("Reload");
        characterController = GetComponent<CharacterController>(); //캐릭터 컨트롤러 컴포넌트

        //transform.localEulerAngles는 부모의 상대적인 회전량을 Degree로 접근 가능하다
        //즉, 좌우회전량을 Degree로 받아온다
        horizontalAngle = transform.localEulerAngles.y;
        verticalAngle = transform.localEulerAngles.x;

        isGrounded = true;
        groundedTimer = 0f;
        verticalSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        CharacterRotate();
        ApplyGravity();
    }

    void CharacterMove()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>(); //키입력 정보를 2D로 받아옴(좌우, 위아래)
        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y); //좌우로만 움직이므로 X,0,Z로 해준다. 

        //magnitude는 벡터의 크기를 나타냄(0,0,0으로부터의 거리)
        if (move.magnitude > 1)//만약 1보다 크면
        {
            move.Normalize(); //우리는 방향만 알아보면 되니까 정규화하여 단위벡터로 만든다.
        }
        move = move * WalkingSpeed * Time.deltaTime; //이동속도
        move = transform.TransformDirection(move); //상대좌표가 아닌 월드좌표로 움직이기 위해서 벡터를 월드공간에서의 벡터로 변경
        characterController.Move(move); //해당 좌표만큼 움직여준다.
    }

    void CharacterRotate()
    {
        Vector2 look = lookAction.ReadValue<Vector2>(); //마우스 움직이는 정보를 2D로 받아옴(상하좌우)

        float turnPlayer = look.x * mouseSens; //마우스 감도를 곱한 좌우 회전 속도
        horizontalAngle += turnPlayer; //마우스를 좌우로 회전한 만큼 더해준다
        if (horizontalAngle >= 360) horizontalAngle += 360; //0~360으로 범위를 맞추주기 위한 조건문
        if (horizontalAngle < 0) horizontalAngle += 360;

        Vector3 currentAngle = transform.localEulerAngles; //현재 상대적인 회전량을(모든방향) 저장
        currentAngle.y = horizontalAngle; //씬에서 좌우회전은 Y축회전이므로 좌우 회전량을 저장
        transform.localEulerAngles = currentAngle; //그대로 다시 적용

        float turnCam = look.y * mouseSens; //마우스 감도를 곱한 상하 회전 속도
        verticalAngle -= turnCam; //계산한 상하 회전량을 빼줌 Why? 씬에서 오브젝트는 X축방향을 아래로 돌리면 값이 증가함
        verticalAngle = Mathf.Clamp(verticalAngle, -89f, 89f); //하한선과 상한선
        currentAngle = CameraTransform.localEulerAngles; //위에랑 같은 작업
        currentAngle.x = verticalAngle;
        CameraTransform.localEulerAngles = currentAngle;
    }

    void ApplyGravity()
    {
        verticalSpeed -= gravity * Time.deltaTime;

        if (verticalSpeed < -terminalSpeed) //최대값을 정해주자
        {
            verticalSpeed = -terminalSpeed;
        }

        Vector3 verticalMove = new Vector3(0, verticalSpeed, 0);
        verticalMove *= Time.deltaTime;

        //완벽하진 않아서 값이 계속 섞여서 나옴
        CollisionFlags flag = characterController.Move(verticalMove);

        //위에 부딪혀도 스피드를 0으로 해줬다
        if ((flag & (CollisionFlags.Below | CollisionFlags.Above)) != 0) //CollisionFlags는 enum으로 1,2,4로 구성되어 있다
        {
            verticalSpeed = 0;
        }

        //characterController.isGrounded로도 땅에 붙어있는지 확인가능

        //true가 나오면 무조건 땅이다. 그러므로 한번이라도 true가 나오면 타이머를 초기화
        //그냥 false면 바꿔주면 안됨 => 땅일때도 true, false가 혼합되기 때문
        if (!characterController.isGrounded)
        {
            if (isGrounded) //막 땅에서 벗어나면 isGrounded는 계속 true이다. 
            {
                groundedTimer += Time.deltaTime;
                if (groundedTimer > 0.3f) //공중에 0.3초 이상 있었다면
                { 
                    isGrounded = false; //공중으로 바꿔줌
                }
            }
        }
        else
        {
            isGrounded = true;
            groundedTimer = 0f;
        }

        if(fireAction.WasPerformedThisFrame())
        {
            weapon.FireWeapon();
        }

        if (reloadAction.WasPressedThisFrame()) // 해당 프레임에서 ReloadAction이 활성화되면
        {
            weapon.ReloadWeapon(); // 메소드 실행
        }
    }

    public void OnJump()
    {
        if(isGrounded)
        {
            verticalSpeed = jumpSpeed;
            isGrounded = false; //점프는 명시적으로 땅에서 떨어져야함
        }
    }

    //void OnFire()
    //{
    //    animator.SetTrigger("Fire");
    //}
}
