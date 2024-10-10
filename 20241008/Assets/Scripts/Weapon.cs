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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) // 상태가 idle이면
        {
            animator.SetTrigger("Fire");
            RayCastFire();

        }
    }
    public void ReloadWeapon()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) // 상태가 idle이면
        {
            animator.SetTrigger("Reload");
        }
    }

    void RayCastFire()
    {
        Camera cam = Camera.main;

        RaycastHit hit;
        Ray r = cam.ViewportPointToRay(Vector3.one / 2); //카메라의 뷰포트에서 툭정지점을 향하는 광선을 쏜다

        Debug.Log(r.direction);
        Vector3 hitPosition = r.origin + r.direction * 200; //origin : 시작점, direction : 방향 => 결국 방향에 200을 곱하고 시작점에서 더해주면 광선의 도착점이 된다.
        //direction은 방향벡터로 정규화된 벡터이다. 크기가 1이라는뜻

        if(Physics.Raycast(r, out hit, 1000)) //Physics.Raycast는 쏠 광선과 맞은 물체의 정보를 받아오는 hit, 최대거리를 인자로 받는다.
        {
            hitPosition = hit.point; //물체에 히트된 지점을 받아온다
        }

        GameObject go = Instantiate(trailPrefab);
        Vector3[] pos = new Vector3[] { firingPosition.position, hitPosition }; //벡터 배열에 시작점과 도착점 저장
        go.GetComponent<LineRenderer>().SetPositions(pos); //라인을 그려주기위해 시작점과 도착점 정보를 넘김
    }
}
