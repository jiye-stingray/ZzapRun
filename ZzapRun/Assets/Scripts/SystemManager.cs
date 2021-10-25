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
        //�̹� ������Ʈ�� �����Ǿ� ���� ��
        if (instance != null)
        {
            Debug.LogError("SystemManager error! Singletone error");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    //�÷��̾�
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
