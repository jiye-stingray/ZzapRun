using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;      //물리
    public GameManager gameManager;

    [Header("jump")]
    public int jumpCount;   //현재 점프 횟수
    int jumpCountMax = 2;    //가장큰 점프 수
    [SerializeField]
    int jumpForce = 2;      //점프할때 가해지는 힘
    [SerializeField]
    float maxForce = 5.0f;     //점프하는 순간에 있을 수 있는 가장 큰 힘
    bool isGround;              //땅 체크

    [Header("play")]
    [SerializeField]
    public int score = 0;
    [SerializeField]
    public int health = 0;
    int MAXHP = 100;
    public float runingTime = 1f;        //달리다가 이 시간간격 만큼 체력이 감소
    public float curruningTime = 0f;    //현재 달리고 있던 시간   

    Animator anim;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //체력 감소
        StartCoroutine(Reducedstamina());
        health = MAXHP;
    }
    void Update()
    {
        jump();
    
    }
    void FixedUpdate()
    {
        //땅 체크
        GroundCheak();

    }

    public void jump()
    {
        if (isGround && jumpCount >= jumpCountMax)
            jumpCount = 0;
        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            health--;
            anim.SetBool("isJumping",true);
            if (rigid.velocity.y >= maxForce)
            {
                rigid.velocity = Vector2.zero;
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
            anim.SetBool("isJumping", false);
        }
        else
        {
            isGround = false;
            anim.SetBool("isJumping", true);
        }
    }

    void getScore(int score, Item.Type type)
    {
        if (type == Item.Type.Gold)
        {
            this.score += score;
        }
        else if(type == Item.Type.heart)
        {
            if (health + score > MAXHP)
                score = MAXHP - health;
            health += score;
        }
    }

    //지정된 시간 마다 체력 감소
    IEnumerator Reducedstamina()
    {
        
        while (true)
        {
            health--;
            yield return new WaitForSeconds(1);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            getScore(item.score,item.type);
            collision.gameObject.SetActive(false);
        }
    }
    
}
