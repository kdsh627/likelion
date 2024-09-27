using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Gravity = 10f;
    public float Accel = 10f;
    float v = 0;

    public AudioClip UpSound;
    public AudioClip DownSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        v = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(UpSound);
        }
        if (Input.GetButtonUp("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(DownSound);
        }

        // 스페이스바를 누를 때 올라가고
        if (Input.GetButton("Jump"))
        {
            v -= Accel * Time.deltaTime;
        }
        // 아니면 떨어짐
        else
        {
            v += Gravity * Time.deltaTime;
        }
    }

    // 물리계산은 주로 FixedUpdate로 해요
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * v * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.CompareTag("Wall"); -> 태그의 존재여부까지 알 수 있는 함수
        if (collision.gameObject.tag == "Wall") //이건 태그가 존재안하면 에러날수도있음
        {
            int score = (int)GameManager.Instance.Score;

            //하드디스크에 기록을 함
            PlayerPrefs.SetInt("Score", score); //인자는 키, 밸류

            SceneManager.LoadScene("GameOver");
        }
    }
}
