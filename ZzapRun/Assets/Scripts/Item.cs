using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score;       //�÷��̾�� �Ѱ��� �ڽ��� ����
    public string type;     //�������� ������ �����ϱ� ���� ����

    Rigidbody2D rigid;

    void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.left * 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.SetActive(false);
        }
    }
}