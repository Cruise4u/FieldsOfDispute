using System;
using UnityEngine;
using Bolt;

public enum Team
{
    A,
    B,
}

public class User : MonoBehaviour
{
    public Team team;
    public MatchManager matchManager;
    public PoolController poolController;
    public ChampionController championController;
    public UnitManager unitManager;
    public UserController userController;
    public UserRaycast userRaycast;
    public UserCanvas userCanvas;
    public bool isPlayerTurn;

    public void Init()
    {
        userRaycast.Init();
        userCanvas.Init();
        poolController.Init();
        championController.Init();
        unitManager.Init();
    }

}
