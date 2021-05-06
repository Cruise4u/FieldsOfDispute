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
    public UserCanvas userCanvas;
    public UserController userController;
    public ChampionController championController;
    public bool isPlayerTurn;

    public void Init()
    {
        if(gameObject.TryGetComponent(out AIController controller))
        {
            team = Team.B;
        }
        else
        {
            team = Team.A;
        }
    }

}
