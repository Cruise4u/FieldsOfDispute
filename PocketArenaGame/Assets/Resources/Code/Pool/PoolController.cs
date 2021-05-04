using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string poolName;
    public Stack<GameObject> poolStack;
    public GameObject poolPrefab;
    public int poolSize;

}
