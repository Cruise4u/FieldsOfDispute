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


    public GameObject textObject;

    public void Init()
    {
        playerCanvas.SetCameraForCanvasRenderMode(playerTeam);
    }



    public void WriteMessage(string message)
    {
        textObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = message;
    }

}
