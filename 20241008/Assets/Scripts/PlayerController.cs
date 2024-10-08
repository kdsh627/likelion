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
        Cursor.lockState = CursorLockMode.Locked; // ���콺�� ���� �߾� ��ǥ�� ������Ű�� ���콺Ŀ���� �Ⱥ���

        InputActionAsset inputActions = GetComponent<PlayerInput>().actions; //�÷��̾� ��ǲ�� �׼��� �޾ƿ´�.

        moveAction = inputActions.FindAction("Move"); //Move�� ���� �и�
        lookAction = inputActions.FindAction("Look"); //LooK�� ���� �и�

        characterController = GetComponent<CharacterController>(); //ĳ���� ��Ʈ�ѷ� ������Ʈ

        //transform.localEulerAngles�� �θ��� ������� ȸ������ Degree�� ���� �����ϴ�
        //��, �¿�ȸ������ Degree�� �޾ƿ´�
        horizontalAngle = transform.localEulerAngles.y;
        verticalAngle = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
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
}
