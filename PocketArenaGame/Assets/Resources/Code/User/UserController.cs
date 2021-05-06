using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UserController : MonoBehaviour
{
    public GameObject pickedUnit;
    public bool isPlayerTurn;
    public bool isUnitPicked;
    public void CastSpell()
    {

    }

    public void OrderSpellCastToAllUnitsOfType()
    {

    }

    public GameObject PickUnit()
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

    public void DropUnit()
    {
        pickedUnit = null;
        isUnitPicked = false;
        Debug.Log("Unit dropped!");
    }

    public void SwapAdjacentUnits()
    {
        var raycast = gameObject.GetComponent<UserRaycast>();
        raycast.ShootRaycast(raycast.userCamera, raycast.defaultMask);
        if(raycast.hittedObject != null)
        {
            var grid = FindObjectOfType<FieldGrid>();
            var adjacentUnitCoordinates = pickedUnit.GetComponent<UnitController>().currentNode.coordinates;
            var unitCoordinates = raycast.hittedObject.GetComponent<UnitController>().currentNode.coordinates;
            if(raycast.hittedObject.GetComponent<UnitController>() && raycast.hittedObject != pickedUnit)
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

    public void OrderMovementToAllUnits()
    {
        gameObject.GetComponent<UnitManager>().OrderMovement();
    }

}