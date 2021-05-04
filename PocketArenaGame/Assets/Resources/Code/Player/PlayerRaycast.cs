using System;
using UnityEngine;
public class PlayerRaycast : MonoBehaviour
{
    public GameObject hittedObject;
    public RaycastHit playerCastHit;
    public Ray playerRay;

    public void ShootRaycast(Camera camera,LayerMask mask)
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
