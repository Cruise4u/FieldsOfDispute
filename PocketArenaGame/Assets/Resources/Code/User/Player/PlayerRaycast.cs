using System;
using UnityEngine;

public class PlayerRaycast : UserRaycast
{
    public override void Init()
    {
        defaultMask = LayerMask.GetMask("Default");
        userMask = LayerMask.GetMask("NodeA");
        enemyMask = LayerMask.GetMask("NodeB");
    }

    public override void ShootRaycast(Camera camera, LayerMask mask)
    {
        userRay = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(userRay, out userCastHit, camera.farClipPlane, mask))
        {
            hittedObject = userCastHit.collider.gameObject;
        }
        else
        {
            hittedObject = null;
        }
    }
}