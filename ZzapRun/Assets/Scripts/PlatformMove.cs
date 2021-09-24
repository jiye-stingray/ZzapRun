using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    Vector3 playerPos;
    [SerializeField]
    float movePosition;
    public float movespeed;



    void Start()
    {
        playerPos = transform.position;
        Move();
    }
    void FixedUpdate()
    {
        playerPos = transform.position;
        
    }

    void Move()
    {
        transform.position = Vector3.right * movespeed;
        Invoke("Move", movespeed);
    }
}
