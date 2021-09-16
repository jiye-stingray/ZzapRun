using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    MeshRenderer render;

    public float speed;
    private float offset;

    void Awake()
    {
        render = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offset, 2);
    }
}
