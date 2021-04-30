using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    public PlayerController[] controllers;

    public void Init()
    {

    }

    public void FlipCoin()
    {
        int randomNumber = Random.Range(0, 1);
        if(randomNumber == 0)
        {
            controllers[1].isPlayerTurn = false;
            controllers[0].isPlayerTurn = true;
        }
        else
        {
            controllers[0].isPlayerTurn = false;
            controllers[1].isPlayerTurn = true;
        }
    }



    public void Start()
    {

    }



}
