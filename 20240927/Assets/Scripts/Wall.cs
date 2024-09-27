using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float Speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * Speed);

        if(transform.position.x < -10)
        {
            //this를 쓰면 스크립트 컴포넌트가 삭제된다
            Destroy(gameObject); //MonoBehaviour에서 제공한다. 이 스크립트가 붙어있는 gameObject를 말함
        }

    }
}
