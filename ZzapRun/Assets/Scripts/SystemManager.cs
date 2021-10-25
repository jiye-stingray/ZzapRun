using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    static SystemManager instance = null;

    public static SystemManager Instance
    {
        get
        {
            return instance;

        }
    }
    void Awake()
    {
        //이미 오브젝트가 생성되어 있을 때
        if (instance != null)
        {
            Debug.LogError("SystemManager error! Singletone error");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    //플레이어
    [SerializeField]
    PlayerController player;
    public PlayerController Hero
    {
        get
        {
            return player;
        }
    }

    [SerializeField]
    ObjectManager objectManager;
    public ObjectManager objectPool
    {
        get
        {
            return objectManager;
        }
    }


}
