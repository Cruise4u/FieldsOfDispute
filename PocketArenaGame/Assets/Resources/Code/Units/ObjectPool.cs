using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolName
{
    ArcherPool,
    KnightPool,
    MagePool,
}

public class ObjectPool : MonoBehaviour
{
    public PoolName spawnedPoolName;
    public List<Pool> poolList;
    public Dictionary<PoolName, Queue<GameObject>> queueDictionary;
    public Dictionary<PoolName, Pool> poolDictionary;

    
    public void Awake()
    {
        queueDictionary = new Dictionary<PoolName, Queue<GameObject>>();
        poolDictionary = new Dictionary<PoolName, Pool>();
        AddEntriesToPoolDictionary();
        FillQueue();
    }

    public void AddEntriesToPoolDictionary()
    {
        foreach(Pool pool in poolList)
        {
            poolDictionary.Add(pool.poolName, pool);
        }
    }

    public void FillQueue()
    {
        foreach (Pool pool in poolList)
        {
            Queue<GameObject> poolQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                var instanceGO = Instantiate(pool.poolPrefab);
                instanceGO.SetActive(false);
                poolQueue.Enqueue(instanceGO);
            }
            queueDictionary.Add(pool.poolName, poolQueue);
            Debug.Log(pool.poolId);
        }
    }

    public void ReturnToPool(PoolName poolName,GameObject go)
    {
        go.SetActive(false);
        queueDictionary[poolName].Enqueue(go);
    }

    public void SpawnPrefab(PoolName poolName, Vector3 spawnPosition)
    {
        if(IsQueueNotEmpty(poolName))
        {
            var prefabInstance = queueDictionary[poolName].Dequeue();
            poolDictionary[poolName].lastPrefabInstantiated = prefabInstance;
            if (prefabInstance.activeSelf != true)
            {
                prefabInstance.SetActive(true);
                prefabInstance.transform.position = spawnPosition;
                queueDictionary[poolName].Enqueue(prefabInstance);
            }
        }
    }

    public bool IsQueueNotEmpty(PoolName poolName)
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

    public PoolName PickRandomObjectByPoolName()
    {
        string[] randomPoolName = new string[poolList.Count];
        for (int i = 0; i < poolList.Count - 1; i++)
        {
            if(IsQueueNotEmpty(poolList[i].poolName))
            {
                randomPoolName[i] = poolList[i].poolName.ToString();
                Debug.Log(randomPoolName[i]);
            }
        }
        int randomNumber = Random.Range(0, randomPoolName.Length);
        Debug.Log(randomNumber);
        var finalName = poolDictionary[poolList[randomNumber].poolName].poolName;
        return finalName;
    }

}

[System.Serializable]
public class Pool
{
    public GameObject lastPrefabInstantiated;
    public GameObject poolPrefab;
    public int poolSize;
    public int poolId;
    public PoolName poolName;
}