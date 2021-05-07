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
        userRay = new Ray(camera.transform.position, rayDirectionToNode);
        if(Physics.Raycast(userRay,out userCastHit, camera.farClipPlane, mask))
        {
            hittedObject = userCastHit.collider.gameObject;
            var direction = hittedObject.transform.position - camera.transform.position;
        }
        else
        {
            hittedObject = null;
        }
        Debug.Log(hittedObject);
    }

    public void SetNodeTarget(Vector2 coordinates)
    {
        var grid = FindObjectOfType<FieldGrid>();
        var node = grid.nodeCoordinatesDictionary[coordinates].GetComponent<FieldGridNode>();
        nodeTarget = node;
    }
}
