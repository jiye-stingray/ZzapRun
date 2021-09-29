using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnObjects;
    public GameObject[] item;

    void Start()
    {
        SpwanItem();
    }

    void SpwanItem()
    {
        int spawnPosition = Random.Range(0, 4);
        int itemtype = Random.Range(0, 3);
        Instantiate(item[itemtype],spawnObjects[spawnPosition].position ,
                                    spawnObjects[spawnPosition].rotation);

        Invoke("SpwanItem", 0.3f);
    }
}
