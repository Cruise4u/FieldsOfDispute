using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UserController : MonoBehaviour
{
    public int spawnNumber;
    public List<UnitController> unitList;
    public GameObject pickedUnit;
    public bool isUnitPicked;
    public virtual void Init()
    {
        
    }

    public virtual GameObject PickUnit()
    {
        return pickedUnit;
    }
    public virtual bool IsNumberOfSpawnsDepleted()
    {
        bool condition;
        if (spawnNumber < 1)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public virtual bool IsThereAnyUnitOnField()
    {
        bool condition;
        if (unitList != null && unitList.Count > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public virtual void DropUnit()
    {
        pickedUnit = null;
        isUnitPicked = false;
    }
    public virtual void RequestUnitsSpellCast()
    {

    }
    public virtual void RequestUnitsMovement()
    {
        foreach (UnitController controller in unitList)
        {
            controller.TriggerMovementOrder();
        }
    }
    public virtual void IncreaseSpawnsPerTurn(int turnNumber)
    {
        var multipleThree = turnNumber % 3;
        if (turnNumber != 1 || turnNumber == multipleThree)
        {
            spawnNumber += 1;
        }
    }
    public virtual void SwapAdjacentUnits()
    {
        
    }
    public virtual void ChooseNodeToSpawn()
    {
        
    }
}