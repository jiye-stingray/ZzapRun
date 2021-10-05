using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;      //물리
    public int jumpCount;   //현재 점프 횟수
    int jumpCountMax = 2;       //가장큰 점프 수

    [SerializeField]
    int jumpForce = 2;      //점프할때 가해지는 힘
    [SerializeField]
    float maxForce = 5.0f;     //점프하는 순간에 있을 수 있는 가장 큰 힘
    bool isGround;              //땅 체크

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jumpCheck();
        jump();
    }
    void FixedUpdate()
    {
        //땅 체크
        GroundCheak();

    }

    public void jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            float velY = rigid.velocity.y;
            if (rigid.velocity.y >= maxForce)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, maxForce);
            }
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }


    void GroundCheak()
    {
        RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector2.down, 1, LayerMask.GetMask("Platform"));
        if (rayhit.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    void jumpCheck()
    {
        if (isGround && jumpCount >= jumpCountMax)
            jumpCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
        }
    }
}
