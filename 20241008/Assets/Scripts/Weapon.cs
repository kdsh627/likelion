using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject trailPrefab;
    public Transform firingPosition;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireWeapon()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) // ���°� idle�̸�
        {
            animator.SetTrigger("Fire");
            RayCastFire();

        }
    }
    public void ReloadWeapon()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) // ���°� idle�̸�
        {
            animator.SetTrigger("Reload");
        }
    }

    void RayCastFire()
    {
        Camera cam = Camera.main;

        RaycastHit hit;
        Ray r = cam.ViewportPointToRay(Vector3.one / 2); //ī�޶��� ����Ʈ���� ���������� ���ϴ� ������ ���

        Debug.Log(r.direction);
        Vector3 hitPosition = r.origin + r.direction * 200; //origin : ������, direction : ���� => �ᱹ ���⿡ 200�� ���ϰ� ���������� �����ָ� ������ �������� �ȴ�.
        //direction�� ���⺤�ͷ� ����ȭ�� �����̴�. ũ�Ⱑ 1�̶�¶�

        if(Physics.Raycast(r, out hit, 1000)) //Physics.Raycast�� �� ������ ���� ��ü�� ������ �޾ƿ��� hit, �ִ�Ÿ��� ���ڷ� �޴´�.
        {
            hitPosition = hit.point; //��ü�� ��Ʈ�� ������ �޾ƿ´�
        }

        GameObject go = Instantiate(trailPrefab);
        Vector3[] pos = new Vector3[] { firingPosition.position, hitPosition }; //���� �迭�� �������� ������ ����
        go.GetComponent<LineRenderer>().SetPositions(pos); //������ �׷��ֱ����� �������� ������ ������ �ѱ�
    }
}
