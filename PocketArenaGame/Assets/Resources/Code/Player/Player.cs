using System;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Bolt;
using TMPro;

public class Player : MonoBehaviourPunCallbacks
{
    public PlayerTeam playerTeam;
    public PlayerCanvas playerCanvas;
    public PlayerController playerController;
    public ChampionController championController;
    public bool isPlayerTurn;

  
    public void Init()
    {
        if(photonView.ViewID == 1001)
        {
            playerTeam = PlayerTeam.TeamA;
        }
        else
        {
            playerTeam = PlayerTeam.TeamB;
        }
        InitializeComponents();
    }

    public void InitializeComponents()
    {
        playerController.Init(playerTeam);
        championController.Init(playerTeam);
    }

}
