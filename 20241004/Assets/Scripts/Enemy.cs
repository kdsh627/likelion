using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Hp = 0;
    public float Speed;
    private CompositeCollider2D TerrainCollider;
    public Collider2D FrontBottomCollider;
    public Collider2D FrontCollider;

    Vector2 vx;

    private void Awake()
    {
        TerrainCollider = GameObject.FindWithTag("Terrain").GetComponent<CompositeCollider2D>();
    }

    void Start()
    {
        vx = Vector2.right * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (FrontCollider.IsTouching(TerrainCollider) || !FrontBottomCollider.IsTouching(TerrainCollider))
        {
            vx = -vx;
            transform.localScale = new Vector2(-transform.localScale.x, 1);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(vx * Time.fixedDeltaTime);
    }

    public void Hit(int damage)
    {
        Hp -= damage;
        if(Hp<=0)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().angularVelocity = 720;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            GetComponent<BoxCollider2D>().enabled = false;

            Invoke("DestroyThis", 2f);
        }
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
