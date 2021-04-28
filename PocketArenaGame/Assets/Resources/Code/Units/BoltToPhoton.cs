﻿using System;
using UnityEngine;
using Photon.Pun;
using Bolt;
using Photon.Realtime;

public class BoltToPhoton : MonoBehaviourPunCallbacks
{
    public GameObject playerA;
    public GameObject playerB;

    public override void OnConnectedToMaster()
    {
        CustomEvent.Trigger(gameObject, "OnConnectedToMaster");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        CustomEvent.Trigger(gameObject, "OnDisconnected");
    }

    public override void OnJoinedRoom()
    {
        CustomEvent.Trigger(playerA, "OnJoinedRoom");
    }
}