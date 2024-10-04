using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float TimeAdd = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //방법 1 : N초 후에 삭제
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        GetComponent<Animator>().SetTrigger("Eaten");
    //        GetComponent<Collider2D>().enabled = false;
    //        Invoke("DestroyThis", 0.6f);
    //    }
    //}
    //void DestroyThis()
    //{
    //    Destroy(gameObject);
    //}

    //방법 2 : 시간 명시 없이 애니메이션 종료 후 삭제를 호출
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.AddTime(TimeAdd);
            GetComponent<Animator>().SetTrigger("Eaten");
            GetComponent<Collider2D>().enabled = false;
        }
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
    }


}
