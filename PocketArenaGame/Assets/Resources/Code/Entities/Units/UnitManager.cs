using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<UnitController> unitList;
    public int numberOfSpawnsPerTurn;

    public void Init()
    {
        numberOfSpawnsPerTurn = Mathf.Clamp(numberOfSpawnsPerTurn, 1, 3);
    }

 

    public void IncreaseSpawnsPerTurn()
    {
        numberOfSpawnsPerTurn += 1; 
    }

    public void RequestMovementOrder()
    {
        foreach(UnitController controller in unitControllers)
        {
            controller.TriggerMovementOrder();
        }
    }

    public void RequestAbilityCastingOrder()
    {

    }

    

}
