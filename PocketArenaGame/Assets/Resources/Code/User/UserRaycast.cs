using System;
using UnityEngine;
public class UserRaycast : MonoBehaviour
{
    public Camera userCamera;
    public GameObject hittedObject;
    public RaycastHit userCastHit;
    public Ray userRay;

    public LayerMask spawnMask;
    public LayerMask defaultMask;
    public LayerMask userMask;
    public LayerMask enemyMask;
    public virtual void Init()
    {
        
    }

    public virtual void ShootRaycast(Camera camera,LayerMask mask)
    {

    }
}
