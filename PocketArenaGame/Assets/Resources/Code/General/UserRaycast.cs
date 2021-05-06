using System;
using UnityEngine;
public class UserRaycast : MonoBehaviour
{
    public Camera userCamera;
    public GameObject hittedObject;
    public RaycastHit playerCastHit;
    public Ray playerRay;

    public LayerMask spawnFieldMask;
    public LayerMask playerFieldMask;
    public LayerMask enemyFieldMask;
    public virtual void ShootRaycast(Camera camera,LayerMask mask)
    {

    }
}
