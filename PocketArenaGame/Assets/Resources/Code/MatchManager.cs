using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    public PlayerController[] controllers;
    public int turnNumber;
    public int turnTimer = 30;

    public void Init()
    {

    }

    public bool IsThisTurnTheFirst()
    {
        bool condition;
        if(turnNumber == 1)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }

    public void SwitchTurns()
    {
        if (controllers[0].isPlayerTurn == true)
        {
            controllers[0].isPlayerTurn = false;
            controllers[1].isPlayerTurn = true;
        }
        else
        {
            controllers[1].isPlayerTurn = false;
            controllers[0].isPlayerTurn = true;
        }
    }

    public void RefillManaPoints()
    {

    }

    public void IncreaseManaPoints()
    {

    }
}

