using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    PlayerController player = null;

    [SerializeField]
    Text scoreText;

    
    void Awake()
    {    
        player = SystemManager.Instance.Hero;
    }

    
    void Start()
    {
        scoreText.text = player.score.ToString();
    }
}
