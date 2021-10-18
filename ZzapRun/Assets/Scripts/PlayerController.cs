using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;      //����
    public GameManager gameManager;

    [Header("jump")]
    public int jumpCount;   //���� ���� Ƚ��
    int jumpCountMax = 2;    //����ū ���� ��
    [SerializeField]
    int jumpForce = 2;      //�����Ҷ� �������� ��
    [SerializeField]
    float maxForce = 5.0f;     //�����ϴ� ������ ���� �� �ִ� ���� ū ��
    bool isGround;              //�� üũ

    [Header("play")]
    [SerializeField]
    public int score = 0;
    [SerializeField]
    public int health = 0;
    public float runingTime = 1f;        //�޸��ٰ� �� �ð����� ��ŭ ü���� ����
    public float curruningTime = 0f;    //���� �޸��� �ִ� �ð�   

    Animator anim;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //ü�� ����
        StartCoroutine(Reducedstamina());
    }
    void Update()
    {
        jump();

        
        
    }
    void FixedUpdate()
    {
        //�� üũ
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
            anim.SetBool("isJumping", false);
        }
        else
        {
            isGround = false;
            anim.SetBool("isJumping", true);
        }
    }

    void getScore(int score)
    {
        this.score += score;
    }

    //������ �ð� ���� ü�� ����
    IEnumerator Reducedstamina()
    {
        
        while (true)
        {
            health--;
            Debug.Log("ȣ��");
            yield return new WaitForSeconds(1);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            getScore(item.score);
            collision.gameObject.SetActive(false);
        }
    }
    
}
