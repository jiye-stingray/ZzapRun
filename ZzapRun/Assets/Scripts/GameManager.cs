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

    [SerializeField]
    PlayerController player;

    [Header("UI")]
    public Image hpGauge;
    public Text scoreText;

    void Awake()
    {
        player =  SystemManager.Instance.Hero;
        objectPool = FindObjectOfType<ObjectManager>();
        itemObjects = new string[] { "ItemGold", "ItemSilver", "ItemBronze" };
       
    }
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    void Update()
    {
        HpCheck();
        UpdateScore();
    }

    IEnumerator SpawnItem()
    {
        while(true)
        {
            GameObject item = objectPool.GetObj(itemObjects[Random.Range(0, itemObjects.Length)]);
            item.transform.position = spawnObjects[Random.Range(0, spawnObjects.Length)].position;
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    void UpdateScore()
    {
        scoreText.text = player.score.ToString();
    }

    //Ã¼·Â UI
    void HpCheck()
    {
       
        hpGauge.fillAmount = (float)player.health / 100;
        if (player.health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
