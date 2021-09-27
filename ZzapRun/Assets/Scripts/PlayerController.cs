using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;      //물리
    public int jumpCount = 0;   //현재 점프 횟수
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
        //Jump 할 수 있는지 없는지 
        jumpCheck();


    }
    void FixedUpdate()
    {
        GroundCheak();

    }

    public void jump()
    {
        if (rigid.velocity.y < maxForce) //y속도가 최대 속도보다 적을 때
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //위로 jumpForce만큼 힘을 준다
        }
        else //그렇지 않을 때
        {
            //y속도를 maxForce(최대 속도)만큼만 준다.
            rigid.velocity = new Vector2(rigid.velocity.x,maxForce); //y속도를 maxForce(최대 속도)만큼만 준다.
        }
        jumpCount++;
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
        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            jump();
           
        }
        if (isGround && jumpCount >= jumpCountMax)
            jumpCount = 0;
    }
}
