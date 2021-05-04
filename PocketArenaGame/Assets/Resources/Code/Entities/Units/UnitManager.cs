using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<UnitController> unitControllersList;
    public PoolController pool;
    public int numberOfSpawnsPerTurn;

    public bool IsThereAnyUnitOnField()
    {
        bool condition;
        if (unitControllersList != null && unitControllersList.Count > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }

    public void Init()
    {
        numberOfSpawnsPerTurn = Mathf.Clamp(numberOfSpawnsPerTurn, 1, 3);
    }

    public void ChooseNodeToSpawn(Camera camera,LayerMask mask,string concanatedName)
    {
        var raycast = gameObject.GetComponent<PlayerRaycast>();
        var pool = gameObject.GetComponent<PoolController>();
        pool.currentPool = pool.poolDictionary[concanatedName];
        raycast.ShootRaycast(camera, mask);
        if (raycast.hittedObject != null)
        {
            if(raycast.hittedObject.tag == "SpawnNode" && raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed == null)
            {
                pool.SpawnFromPool(raycast.hittedObject.GetComponent<FieldGridNode>().unitStationedTransform.position);
            }
        }
    }

    public void IncreaseSpawnsPerTurn(int turnNumber)
    {
        var multipleThree = turnNumber % 3;
        if(turnNumber != 1 || turnNumber == multipleThree)
        {
            numberOfSpawnsPerTurn += 1;
        }
    }

    public void RequestMovementOrder()
    {
        foreach(UnitController controller in unitControllersList)
        {
            controller.TriggerMovementOrder();
        }
    }

    public void RequestAbilityCastingOrder()
    {

    }

}
