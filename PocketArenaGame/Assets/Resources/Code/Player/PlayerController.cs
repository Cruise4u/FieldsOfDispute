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
    public PlayerTeam playerTeam;
    public PlayerRaycast playerRaycast;
    public ObjectPool unitPoolManager;
    public List<UnitController> unitsList;
    public bool isPlayerTurn;

    public bool IsThereAnyUnitOnField()
    {
        bool condition;
        if (unitsList != null && unitsList.Count > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }

    public void ChooseAvailableNodeToSpawn(PoolName poolName)
    {
        if (playerRaycast.hittedObject != null)
        {
            Debug.Log(playerRaycast.hittedObject);
            if (playerRaycast.hittedObject.TryGetComponent(out FieldGridNode node))
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

    public void RequestMovementOrderToUnits()
    {
        foreach (UnitController controller in unitsList)
        {
            controller.TriggerMovementOrder();
        }
    }

    public void SwapUnits()
    {

    }

    public void CastSpell()
    {

    }

    public void Init()
    {

    }

    public void Start()
    {
        Init();
    }
}


