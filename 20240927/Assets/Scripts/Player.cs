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

        // �����̽��ٸ� ���� �� �ö󰡰�
        if (Input.GetButton("Jump"))
        {
            v -= Accel * Time.deltaTime;
        }
        // �ƴϸ� ������
        else
        {
            v += Gravity * Time.deltaTime;
        }
    }

    // ��������� �ַ� FixedUpdate�� �ؿ�
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * v * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.CompareTag("Wall"); -> �±��� ���翩�α��� �� �� �ִ� �Լ�
        if (collision.gameObject.tag == "Wall") //�̰� �±װ� ������ϸ� ��������������
        {
            int score = (int)GameManager.Instance.Score;

            //�ϵ��ũ�� ����� ��
            PlayerPrefs.SetInt("Score", score); //���ڴ� Ű, ���

            SceneManager.LoadScene("GameOver");
        }
    }
}
