using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    public User[] users;
    public int turnNumber;
    public float turnTimer = 30.0f;

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
        if (users[0].isPlayerTurn == true)
        {
            users[0].isPlayerTurn = false;
            users[1].isPlayerTurn = true;
        }
        else
        {
            users[1].isPlayerTurn = false;
            users[0].isPlayerTurn = true;
        }
    }

 
}

