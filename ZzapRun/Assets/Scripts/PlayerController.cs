using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;      //����
    public int jumpCount = 0;   //���� ���� Ƚ��
    int jumpCountMax = 2;       //����ū ���� ��

    [SerializeField]
    int jumpForce = 2;      //�����Ҷ� �������� ��
    [SerializeField]
    float maxForce = 5.0f;     //�����ϴ� ������ ���� �� �ִ� ���� ū ��
    bool isGround;              //�� üũ
    
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Jump �� �� �ִ��� ������ 
        jumpCheck();


    }
    void FixedUpdate()
    {
        GroundCheak();

    }

    public void jump()
    {
        if (rigid.velocity.y < maxForce) //y�ӵ��� �ִ� �ӵ����� ���� ��
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //���� jumpForce��ŭ ���� �ش�
        }
        else //�׷��� ���� ��
        {
            //y�ӵ��� maxForce(�ִ� �ӵ�)��ŭ�� �ش�.
            rigid.velocity = new Vector2(rigid.velocity.x,maxForce); //y�ӵ��� maxForce(�ִ� �ӵ�)��ŭ�� �ش�.
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
