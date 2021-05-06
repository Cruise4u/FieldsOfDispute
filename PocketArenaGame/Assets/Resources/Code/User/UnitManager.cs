using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<UnitController> unitControllersList;
    public PoolController pool;
    public int numberOfSpawnsPerTurn;

    public List<GameObject> availableObjects;

    public void Init()
    {
        numberOfSpawnsPerTurn = Mathf.Clamp(1, 0, 3);
    }

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
    public void ChooseNodeToSpawn()
    {
        if(numberOfSpawnsPerTurn > 0)
        {
            var raycast = gameObject.GetComponent<UserRaycast>();
            var pool = gameObject.GetComponent<PoolController>();
            raycast.ShootRaycast(raycast.userCamera, raycast.userMask);
            if (raycast.hittedObject != null)
            {
                if(raycast.hittedObject.tag == "SpawnNode" && raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed == null)
                {
                    var instance = pool.GetObjectFromTopOfStack();
                    pool.SpawnFromPool(raycast.hittedObject.GetComponent<FieldGridNode>().unitStationedTransform.position);
                    raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed = instance;
                    instance.GetComponent<UnitController>().currentNode = raycast.hittedObject.GetComponent<FieldGridNode>();
                    numberOfSpawnsPerTurn -= 1;
                }
            }
        }
    }
    public void OrderMovement()
    {
        foreach(UnitController controller in unitControllersList)
        {
            controller.TriggerMovementOrder();
        }
    }
    public void OrderSpellCasting()
    {

    }
    public bool IsNumberOfSpawnsDepleted()
    {
        bool condition;
        Debug.Log(numberOfSpawnsPerTurn);
        if (numberOfSpawnsPerTurn < 1)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public void IncreaseSpawnsPerTurn(int turnNumber)
    {
        var multipleThree = turnNumber % 3;
        if (turnNumber != 1 || turnNumber == multipleThree)
        {
            numberOfSpawnsPerTurn += 1;
        }
    }
}
