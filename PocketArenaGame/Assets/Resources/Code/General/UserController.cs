using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UserController : MonoBehaviour
{
    public bool isPlayerTurn;

    //Implementation of method for sub-classes
    public virtual void OrderMovementToAllUnits()
    {
        
    }

    public virtual void OrderSpellCastToAllUnitsOfType()
    {

    }

    public virtual void SwapAdjacentUnits()
    {

    }

    public virtual void CastSpell()
    {

    }

}