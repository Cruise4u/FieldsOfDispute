using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public enum PlayerTeam
{
    TeamA,
    TeamB,
}

public class PlayerController : MonoBehaviour
{
    public PlayerRaycast playerRaycast;
    public PlayerTeam playerTeam;
    public ObjectPool unitPoolManager;
    public int[] borderNode;
    public bool isPlayerTurn;

    public void Init()
    {

    }

    public void Start()
    {
        Init();
    }

    public void OnTurnStart()
    {

    }

    public void ChooseAvailableNodeToSpawn(PoolName poolName)
    {
        if(playerRaycast.hittedObject != null)
        {
            Debug.Log(playerRaycast.hittedObject);
            if(playerRaycast.hittedObject.TryGetComponent(out FieldGridNode node))
            {
                Debug.Log("It has FieldGridNode Component");
                if (node.unitStationed == null)
                {
                    unitPoolManager.SpawnFromPool(node.unitStationedTransform.position, poolName);
                    node.unitStationed = unitPoolManager.lastPrefabInstantiated;
                    node.unitStationed.tag = playerTeam.ToString();
                    unitPoolManager.lastPrefabInstantiated.GetComponent<UnitController>().currentNode = node;
                }
            }
        }
    }

    public void SwapUnits()
    {

    }

    public void CastSpell()
    {

    }


}


