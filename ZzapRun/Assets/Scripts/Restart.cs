using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void RestartBtn()
    {
        Destroy(player);
        SceneManager.LoadScene("GameScene");
    }
}
