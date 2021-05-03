﻿using System;
using UnityEngine;
public static class PlayerRaycast
{
    public static GameObject hittedObject;
    public static RaycastHit playerCastHit;
    public static Ray playerRay;

    public static void ShootRaycast(Camera camera,LayerMask mask)
    {
        playerRay = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(playerRay, out playerCastHit, camera.farClipPlane, mask))
        {
            hittedObject = playerCastHit.collider.gameObject;
        }
        else
        {
            hittedObject = null;
        }
    }
}
