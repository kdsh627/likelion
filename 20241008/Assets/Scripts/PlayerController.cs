using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float terminalSpeed = 20f; //���ܼӵ�, ��ü���п��� ��ü�� �ӵ��� �ܺ��� �ٸ����� ���������� �ӵ��� ��������
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
        Cursor.lockState = CursorLockMode.Locked; // ���콺�� ���� �߾� ��ǥ�� ������Ű�� ���콺Ŀ���� �Ⱥ���

        InputActionAsset inputActions = GetComponent<PlayerInput>().actions; //�÷��̾� ��ǲ�� �׼��� �޾ƿ´�.

        moveAction = inputActions.FindAction("Move"); //Move�� ���� �и�
        lookAction = inputActions.FindAction("Look"); //LooK�� ���� �и�
        fireAction = inputActions.FindAction("Fire");
        reloadAction = inputActions.FindAction("Reload");
        characterController = GetComponent<CharacterController>(); //ĳ���� ��Ʈ�ѷ� ������Ʈ

        //transform.localEulerAngles�� �θ��� ������� ȸ������ Degree�� ���� �����ϴ�
        //��, �¿�ȸ������ Degree�� �޾ƿ´�
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
        Vector2 moveVector = moveAction.ReadValue<Vector2>(); //Ű�Է� ������ 2D�� �޾ƿ�(�¿�, ���Ʒ�)
        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y); //�¿�θ� �����̹Ƿ� X,0,Z�� ���ش�. 

        //magnitude�� ������ ũ�⸦ ��Ÿ��(0,0,0���κ����� �Ÿ�)
        if (move.magnitude > 1)//���� 1���� ũ��
        {
            move.Normalize(); //�츮�� ���⸸ �˾ƺ��� �Ǵϱ� ����ȭ�Ͽ� �������ͷ� �����.
        }
        move = move * WalkingSpeed * Time.deltaTime; //�̵��ӵ�
        move = transform.TransformDirection(move); //�����ǥ�� �ƴ� ������ǥ�� �����̱� ���ؼ� ���͸� ������������� ���ͷ� ����
        characterController.Move(move); //�ش� ��ǥ��ŭ �������ش�.
    }

    void CharacterRotate()
    {
        Vector2 look = lookAction.ReadValue<Vector2>(); //���콺 �����̴� ������ 2D�� �޾ƿ�(�����¿�)

        float turnPlayer = look.x * mouseSens; //���콺 ������ ���� �¿� ȸ�� �ӵ�
        horizontalAngle += turnPlayer; //���콺�� �¿�� ȸ���� ��ŭ �����ش�
        if (horizontalAngle >= 360) horizontalAngle += 360; //0~360���� ������ �����ֱ� ���� ���ǹ�
        if (horizontalAngle < 0) horizontalAngle += 360;

        Vector3 currentAngle = transform.localEulerAngles; //���� ������� ȸ������(������) ����
        currentAngle.y = horizontalAngle; //������ �¿�ȸ���� Y��ȸ���̹Ƿ� �¿� ȸ������ ����
        transform.localEulerAngles = currentAngle; //�״�� �ٽ� ����

        float turnCam = look.y * mouseSens; //���콺 ������ ���� ���� ȸ�� �ӵ�
        verticalAngle -= turnCam; //����� ���� ȸ������ ���� Why? ������ ������Ʈ�� X������� �Ʒ��� ������ ���� ������
        verticalAngle = Mathf.Clamp(verticalAngle, -89f, 89f); //���Ѽ��� ���Ѽ�
        currentAngle = CameraTransform.localEulerAngles; //������ ���� �۾�
        currentAngle.x = verticalAngle;
        CameraTransform.localEulerAngles = currentAngle;
    }

    void ApplyGravity()
    {
        verticalSpeed -= gravity * Time.deltaTime;

        if (verticalSpeed < -terminalSpeed) //�ִ밪�� ��������
        {
            verticalSpeed = -terminalSpeed;
        }

        Vector3 verticalMove = new Vector3(0, verticalSpeed, 0);
        verticalMove *= Time.deltaTime;

        //�Ϻ����� �ʾƼ� ���� ��� ������ ����
        CollisionFlags flag = characterController.Move(verticalMove);

        //���� �ε����� ���ǵ带 0���� �����
        if ((flag & (CollisionFlags.Below | CollisionFlags.Above)) != 0) //CollisionFlags�� enum���� 1,2,4�� �����Ǿ� �ִ�
        {
            verticalSpeed = 0;
        }

        //characterController.isGrounded�ε� ���� �پ��ִ��� Ȯ�ΰ���

        //true�� ������ ������ ���̴�. �׷��Ƿ� �ѹ��̶� true�� ������ Ÿ�̸Ӹ� �ʱ�ȭ
        //�׳� false�� �ٲ��ָ� �ȵ� => ���϶��� true, false�� ȥ�յǱ� ����
        if (!characterController.isGrounded)
        {
            if (isGrounded) //�� ������ ����� isGrounded�� ��� true�̴�. 
            {
                groundedTimer += Time.deltaTime;
                if (groundedTimer > 0.3f) //���߿� 0.3�� �̻� �־��ٸ�
                { 
                    isGrounded = false; //�������� �ٲ���
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

        if (reloadAction.WasPressedThisFrame()) // �ش� �����ӿ��� ReloadAction�� Ȱ��ȭ�Ǹ�
        {
            weapon.ReloadWeapon(); // �޼ҵ� ����
        }
    }

    public void OnJump()
    {
        if(isGrounded)
        {
            verticalSpeed = jumpSpeed;
            isGrounded = false; //������ ��������� ������ ����������
        }
    }

    //void OnFire()
    //{
    //    animator.SetTrigger("Fire");
    //}
}
