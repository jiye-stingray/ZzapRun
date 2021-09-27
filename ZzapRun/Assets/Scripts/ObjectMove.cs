using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject item;

    [SerializeField]
    float moveForce;
    [SerializeField]
    float moveTime;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        item = GetComponent<GameObject>();
    }

    void Start()
    {
        move();
    }

    void Update()
    {
        
    }

    public void move()
    {
        transform.position += Vector3.left;
        Invoke("move", moveTime);
    }
}
