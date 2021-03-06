using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnObjects;
    public ObjectManager objectPool => SystemManager.Instance.ObjectManager;
    public string[] itemObjects;

    [SerializeField]
    PlayerController player => SystemManager.Instance.Hero;

    [Header("UI")]
    public Image hpGauge;
    public Text scoreText;


    
    void Awake()
    {
        

        itemObjects = new string[] { "ItemGold", "ItemSilver", "ItemBronze" , "Heart"};
    }
    void Start()
    {
        StartCoroutine("SpawnItem");
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
            int ranItemIndex = Random.Range(0, 10);
            GameObject item = null;
            if (ranItemIndex == 0)
                item = objectPool.GetObj("Heart");
            else
                item = objectPool.GetObj(itemObjects[Random.Range(0,itemObjects.Length-1)]);

            item.transform.position = spawnObjects[Random.Range(0, spawnObjects.Length)].position;
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    void UpdateScore()
    {
        scoreText.text = player.score.ToString();
    }

    //ü?? UI
    void HpCheck()
    {
       
        hpGauge.fillAmount = (float)player.health / 100;
        if (player.health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
