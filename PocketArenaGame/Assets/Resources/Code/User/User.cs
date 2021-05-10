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
    public UserController userController;
    public UserRaycast userRaycast;
    public UserCanvas userCanvas;
    public bool isPlayerTurn;

    public void Init()
    {
        userRaycast.Init();
        poolController.Init();
        userController.Init();
        championController.Init();
    }

}
