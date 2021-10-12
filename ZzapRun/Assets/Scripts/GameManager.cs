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

    //�������� Ű�� �Լ�
    void SpwanItem()
    {
        GameObject[][] pullObjs = new GameObject[][] { objectPull.itemBronze, objectPull.itemSilver, objectPull.itemGold };


        int renSpawnPosition = Random.Range(0, 4);  //�������� ������ spawn��ġ
        int renItemIndex = Random.Range(0, pullObjs.Length);      //�������� ������ ������ ����
        

        //������ ����
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
