using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public enum PlayerTeam
{
    TeamA,
    TeamB,
}

public class PlayerController : MonoBehaviour
{
    public PlayerTeam playerTeam;
    public PlayerRaycast playerRaycast;
    public PlayerCanvas playerCanvas;
    public PoolController poolController;
    public UnitManager unitManager;
    public bool isPlayerTurn;

    public void RequestMovementOrderToUnits()
    {
        unitManager.RequestMovementOrder();
    }

    public void SwapUnits()
    {

    }

    public void CastSpell()
    {

    }

    public void Init(PlayerTeam playerTeam)
    {
        this.playerTeam = playerTeam;
        playerRaycast.Init(this.playerTeam);
        playerCanvas.Init(this.playerTeam);
        poolController.Init();
        unitManager.Init();
    }

}


