using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnObjects;

    public ObjectManager objectPull;
    void Start()
    {
        SpwanItem();
    }

    //아이템을 키는 함수
    void SpwanItem()
    {
        GameObject[][] pullObjs = new GameObject[][] { objectPull.itemBronze, objectPull.itemSilver, objectPull.itemGold };


        int renSpawnPosition = Random.Range(0, 4);  //랜덤으로 지정할 spawn위치
        int renItemIndex = Random.Range(0, pullObjs.Length);      //랜덤으로 지정할 아이템 종류
        

        //아이템 스폰
        for (int i = 0; i < pullObjs[renItemIndex].Length; i++)
        {
            if (!pullObjs[renItemIndex][i].activeSelf)
            {
                pullObjs[renItemIndex][i].SetActive(true);
                pullObjs[renItemIndex][i].transform.position = spawnObjects[renSpawnPosition].position;
                break;
            }

        }
        
        Invoke("SpwanItem", 0.3f);
    }

  

}
