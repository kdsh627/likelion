# 2024-10-08 유니티 학습
- PlayerController 코드
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float horizontalAngle;
    float verticalAngle;

    public float WalkingSpeed = 7;
    public float mouseSens = 1;
    public Transform CameraTransform;

    InputAction moveAction;
    InputAction lookAction;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스를 게임 중앙 좌표에 고정시키고 마우스커서가 안보임

        InputActionAsset inputActions = GetComponent<PlayerInput>().actions; //플레이어 인풋의 액션을 받아온다.

        moveAction = inputActions.FindAction("Move"); //Move를 따로 분리
        lookAction = inputActions.FindAction("Look"); //LooK을 따로 분리

        characterController = GetComponent<CharacterController>(); //캐릭터 컨트롤러 컴포넌트

        //transform.localEulerAngles는 부모의 상대적인 회전량을 Degree로 접근 가능하다
        //즉, 좌우회전량을 Degree로 받아온다
        horizontalAngle = transform.localEulerAngles.y;
        verticalAngle = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
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
}

```
