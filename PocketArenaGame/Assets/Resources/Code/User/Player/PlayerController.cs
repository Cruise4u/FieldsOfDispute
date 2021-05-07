using System;
using UnityEngine;

public class PlayerController : UserController 
{
    public override void Init()
    {
        spawnNumber = Mathf.Clamp(1, 0, 3);
    }

    public override GameObject PickUnit()
    {
        var raycast = gameObject.GetComponent<UserRaycast>();
        var user = gameObject.GetComponent<User>();
        raycast.ShootRaycast(raycast.userCamera, raycast.defaultMask);
        if (raycast.hittedObject != null && raycast.hittedObject.GetComponent<UnitController>() && raycast.hittedObject.tag == user.team.ToString())
        {
            pickedUnit = raycast.hittedObject;
            isUnitPicked = true;
        }
        else
        {
            pickedUnit = null;
        }
        return pickedUnit;
    }

    public override void SwapAdjacentUnits()
    {
        var raycast = gameObject.GetComponent<UserRaycast>();
        raycast.ShootRaycast(raycast.userCamera, raycast.defaultMask);
        if (raycast.hittedObject != null)
        {
            var grid = FindObjectOfType<FieldGrid>();
            var adjacentUnitCoordinates = pickedUnit.GetComponent<UnitController>().currentNode.coordinates;
            var unitCoordinates = raycast.hittedObject.GetComponent<UnitController>().currentNode.coordinates;
            if (raycast.hittedObject.GetComponent<UnitController>() && raycast.hittedObject != pickedUnit)
            {
                Debug.Log("Unit Picked!");
                if (adjacentUnitCoordinates.y == unitCoordinates.y + 1 || adjacentUnitCoordinates.y == unitCoordinates.y - 1)
                {
                    var tempNode = raycast.hittedObject.GetComponent<UnitController>().currentNode;
                    raycast.hittedObject.GetComponent<UnitController>().MoveUnitToNode(pickedUnit.GetComponent<UnitController>().currentNode);
                    pickedUnit.GetComponent<UnitController>().MoveUnitToNode(tempNode);

                    tempNode = null;
                    DropUnit();
                }
            }
            else
            {
                DropUnit();
            }
        }
        else
        {
            DropUnit();
        }
    }

    public override void ChooseNodeToSpawn()
    {
        if(spawnNumber > 0)
        {
            var raycast = gameObject.GetComponent<UserRaycast>();
            var pool = gameObject.GetComponent<PoolController>();
            raycast.ShootRaycast(raycast.userCamera, raycast.userMask);
            if (raycast.hittedObject != null)
            {
                if (raycast.hittedObject.tag == "SpawnNode" && raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed == null)
                {
                    var instance = pool.GetObjectFromTopOfStack();
                    pool.SpawnFromPool(raycast.hittedObject.GetComponent<FieldGridNode>().unitStationedTransform.position);
                    raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed = instance;
                    instance.GetComponent<UnitController>().currentNode = raycast.hittedObject.GetComponent<FieldGridNode>();
                    spawnNumber -= 1;
                }
            }
        }
    }
}
