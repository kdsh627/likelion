using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 2;
    public float width = 19f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �����Ӹ��� left�� �����̴� �ڵ��Դϴ�.
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x < -width)
        {
            transform.Translate(new Vector2(width * 2, 0));
        }
    }
}
