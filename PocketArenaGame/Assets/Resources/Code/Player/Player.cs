using System;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Bolt;
using TMPro;

public class Player : MonoBehaviourPunCallbacks
{    
    public PlayerTeam playerTeam;
    public GameObject textObject;

    public void WriteMessage(string message)
    {
        textObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = message;
    }


}
