using System;
using UnityEngine;

public class PlayerRaycast : UserRaycast
{
    public LayerMask spawningMask;
    public LayerMask spellMask;

    public override void ShootRaycast(Camera camera, LayerMask mask)
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