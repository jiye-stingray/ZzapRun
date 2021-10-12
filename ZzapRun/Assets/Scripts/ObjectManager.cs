using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject itemGoldPrefab;
    public GameObject itemSilverPrefab;
    public GameObject itemBronzePrefab;

    public GameObject[] itemGold;
    public GameObject[] itemSilver;
    public GameObject[] itemBronze;

    void Awake()
    {
        //배열 크기 정의
        itemGold = new GameObject[20];
        itemSilver = new GameObject[20];
        itemBronze = new GameObject[20];

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < itemGold.Length; i++)
        {
            itemGold[i] = Instantiate(itemGoldPrefab);
            itemGold[i].SetActive(false);
        }
        for (int i = 0; i < itemSilver.Length; i++)
        {
            itemSilver[i] = Instantiate(itemSilverPrefab);
            itemSilver[i].SetActive(false);
        }
        for (int i = 0; i < itemBronze.Length; i++)
        {
            itemBronze[i] = Instantiate(itemBronzePrefab);
            itemBronze[i].SetActive(false);
        }
    }

    //오브젝트를반환하는
    public GameObject GetObj(string type)
    {
        GameObject[] targetObj = null;
        switch (type) {
            case "ItemGold":
                targetObj = itemGold;
                break;
            case "ItemSilver":
                targetObj = itemSilver;
                break;
            case "ItemBronze":
                targetObj = itemBronze;
                break;
        }
        foreach (GameObject item in targetObj)
        {
            if (!item.activeSelf)
            {
                item.SetActive(true);
                return item;
            }
            
        }
        return null;
    }


}
