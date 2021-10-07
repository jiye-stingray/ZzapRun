using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score;

    Rigidbody2D rigid;

    void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.left * 3;
    }
}
