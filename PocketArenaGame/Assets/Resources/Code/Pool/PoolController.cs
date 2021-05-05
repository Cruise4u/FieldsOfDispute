using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolController : MonoBehaviour
{
    public Pool currentPool;
    public List<Pool> poolList;
    public Dictionary<string, Pool> poolDictionary;
   
    public void Init()
    {
        CreatePoolDictionary();
    }
    public GameObject GetObjectFromTopOfStack()
    {
        return currentPool.poolStack.Peek();
    }
    public void SetCurrentPoolRandomly(string poolName)
    {
        currentPool = poolDictionary[poolName];
    }
    public string GetRandomPoolByName()
    {
        string[] randomPoolName = new string[poolList.Count];
        for (int i = 0; i < poolList.Count - 1; i++)
        {
            if(IsStackIsNotEmpty(poolList[i].poolName))
            {
                randomPoolName[i] = poolList[i].poolName.ToString();
            }
        }
        int randomNumber = Random.Range(0, randomPoolName.Length);
        var finalName = poolDictionary[poolList[randomNumber].poolName].poolName;
        Debug.Log(finalName);
        return finalName;
    }
    public bool AreAllStacksEmpty()
    {
        bool condition;
        int stackNumber = 0;
        foreach(Pool pool in poolList)
        {
            if(pool.poolStack.Count > 0)
            {
                stackNumber += 1;
            }
        }
        if(stackNumber != 0)
        {
            condition = false;
        }
        else
        {
            condition = true;
        }
        return condition;
    }
    public bool IsStackIsNotEmpty(string poolName)
    {
        bool condition;
        if (poolDictionary[poolName].poolStack.Count > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public void CreatePoolStack(Pool pool)
    {
        pool.poolStack = new Stack<GameObject>();
        for (int i = 0; i <= pool.poolSize; i++)
        {
            var instance = Instantiate(pool.poolPrefab);
            instance.SetActive(false);
            pool.poolStack.Push(instance);
        }
    }
    public void CreatePoolDictionary()
    {
        poolDictionary = new Dictionary<string, Pool>();
        foreach(Pool pool in poolList)
        {
            CreatePoolStack(pool);
            poolDictionary.Add(pool.poolName, pool);
        }
    }
    public void SelectPool(string poolName)
    {
        currentPool = poolDictionary[poolName];
    }
    public void SpawnFromPool(Vector3 position)
    {
        var prefabInstance = currentPool.poolStack.Pop();
        if (prefabInstance.activeSelf != true)
        {
            prefabInstance.SetActive(true);
            prefabInstance.transform.position = position;
        }
    }
    public void ReturnToPool(GameObject instance, Pool pool)
    {
        instance.SetActive(false);
        currentPool.poolStack.Push(instance);
    }
}

[System.Serializable]
public class Pool
{
    public Stack<GameObject> poolStack;
    public GameObject poolPrefab;
    public string poolName;
    public int poolSize;
    public Sprite poolIcon;
}
