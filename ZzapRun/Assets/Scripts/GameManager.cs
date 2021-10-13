using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnObjects;
    public ObjectManager objectPool;
    public string[] itemObjects;

    public PlayerController player;

    [Header("UI")]
    public Text scoretext;
    public Image hpGauge;


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
        UpdateScore();
        HpGauge();
    }

    //아이템을 키는 함수
    void SpawnItem()
    {
        GameObject item = objectPool.GetObj(itemObjects[Random.Range(0, itemObjects.Length)]);
        item.transform.position = spawnObjects[Random.Range(0,spawnObjects.Length)].position;

        Invoke("SpawnItem", 0.2f);
    }

    //점수 UI
    void UpdateScore()
    {
        scoretext.text = player.score.ToString();
    }
    //체력 UI
    void HpGauge()
    {
        hpGauge.fillAmount = (float)player.health / 100;
    }
}
