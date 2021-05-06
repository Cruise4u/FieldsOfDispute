using System;
using System.Collections.Generic;
using UnityEngine;

public class AIRaycast : UserRaycast
{
    public FieldGridNode nodeTarget;

    public override void Init()
    {
        defaultMask = LayerMask.GetMask("Default");
        userMask = LayerMask.GetMask("NodeB");
        enemyMask = LayerMask.GetMask("NodeA");
    }

    public override void ShootRaycast(Camera camera, LayerMask mask)
    {
        Vector3 rayDirectionToNode = nodeTarget.gameObject.transform.position - camera.transform.position;
        Vector3 rayPosition = camera.ScreenToWorldPoint(rayDirectionToNode);
        userRay = new Ray(camera.transform.position, rayPosition);
        Debug.DrawLine(userRay.origin, userRay.direction-userRay.origin, Color.red);
        if(Physics.Raycast(userRay,out userCastHit, camera.farClipPlane, mask))
        {
            hittedObject = userCastHit.collider.gameObject;
        }
        else
        {
            hittedObject = null;
        }
    }


}
