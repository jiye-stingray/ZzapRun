using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnObjects;
    public ObjectManager objectPool;
    public string[] itemObjects;

    public PlayerController player;

    [Header("UI")]
    public Image hpGauge;
    public Text scoreText;

    void Awake()
    {
        objectPool = FindObjectOfType<ObjectManager>();
        player = FindObjectOfType<PlayerController>();
        itemObjects = new string[] { "ItemGold", "ItemSilver", "ItemBronze" };
       
    }
    void Start()
    {
        SpawnItem();
    }

    void Update()
    {
        HpCheck();
        UpdateScore();
    }

    //아이템을 키는 함수
    void SpawnItem()
    {
        GameObject item = objectPool.GetObj(itemObjects[Random.Range(0, itemObjects.Length)]);
        item.transform.position = spawnObjects[Random.Range(0,spawnObjects.Length)].position;

        Invoke("SpawnItem", 0.2f);
    }

    void UpdateScore()
    {
        scoreText.text = player.score.ToString();
    }

    //체력 UI
    void HpCheck()
    {
       
        hpGauge.fillAmount = (float)player.health / 100;
        if (player.health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
