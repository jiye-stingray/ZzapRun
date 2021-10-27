using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    GameObject player = null;

    [SerializeField]
    Text scoreText;

    
    void Awake()
    {    
        player = GameObject.Find("Player");
    }

    
    void Start()
    {
        scoreText.text = player.GetComponent<PlayerController>().score.ToString();
    }
}
