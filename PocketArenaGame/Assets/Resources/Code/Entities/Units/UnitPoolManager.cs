using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public class UnitPoolManager : MonoBehaviour
{
    public List<UnitPool> poolList;
    public Dictionary<PoolName, Queue<GameObject>> queueDictionary;
    public Dictionary<PoolName, UnitPool> poolDictionary;
    public GameObject lastPrefabInstantiated;

    public void Awake()
    {
        Init();
        FillPoolDictionary();
        CreatePoolsQueue();
    }

    public void Init()
    {
        queueDictionary = new Dictionary<PoolName, Queue<GameObject>>();
        poolDictionary = new Dictionary<PoolName, UnitPool>();
    }

    public void FillPoolDictionary()
    {
        foreach (UnitPool pool in poolList)
        {
            poolDictionary.Add(pool.poolName, pool);
        }
    }

    public void CreatePoolsQueue()
    {
        foreach (UnitPool pool in poolList)
        {
            Queue<GameObject> poolQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                var instanceGO = Instantiate(pool.poolPrefab);
                instanceGO.SetActive(false);
                poolQueue.Enqueue(instanceGO);
            }
            queueDictionary.Add(pool.poolName, poolQueue);
        }
    }

    public void ReturnToPool(PoolName poolName, GameObject go)
    {
        go.SetActive(false);
        queueDictionary[poolName].Enqueue(go);
    }

    public void SpawnFromPool(Vector3 position, PoolName poolName)
    {
        var prefabInstance = queueDictionary[poolName].Dequeue();
        lastPrefabInstantiated = prefabInstance;
        if (prefabInstance.activeSelf != true)
        {
            prefabInstance.SetActive(true);
            prefabInstance.transform.position = position;
            queueDictionary[poolName].Enqueue(prefabInstance);
        }
    }

    public void ReturnToPool(GameObject poolObject, PoolName poolName)
    {
        poolObject.SetActive(false);
        queueDictionary[poolName].Enqueue(poolObject);
    }

    public bool IsQueueIsNotEmpty(PoolName poolName)
    {
        bool condition;
        if(queueDictionary[poolName].Count != 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }

    public PoolName GetRandomPoolByName()
    {
        string[] randomPoolName = new string[poolList.Count];
        for (int i = 0; i < poolList.Count - 1; i++)
        {
            if (IsQueueIsNotEmpty(poolList[i].poolName))
            {
                randomPoolName[i] = poolList[i].poolName.ToString();
            }
        }
        int randomNumber = Random.Range(0, randomPoolName.Length);
        var finalName = poolDictionary[poolList[randomNumber].poolName].poolName;
        return finalName;
    }
}

[Serializable]
public class UnitPool
{
    public PoolName poolName;
    public GameObject poolPrefab;
    public int poolSize;
}