using System;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public UnitController[] unitControllers;

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
