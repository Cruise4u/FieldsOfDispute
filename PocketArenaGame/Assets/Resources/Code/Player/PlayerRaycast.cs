using System;
using UnityEngine;
public class PlayerRaycast : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject visualizationUnit;
    public GameObject hittedObject;
    public RaycastHit playerCastHit;
    public Ray playerRay;

    public Material ghostMaterial;
    public LayerMask spawningMask;
    public LayerMask spellMask;

    public void Init(PlayerTeam playerTeam)
    {
        if(playerTeam == PlayerTeam.TeamA)
        {
            spawningMask = LayerMask.GetMask("NodeA");
            spellMask = LayerMask.GetMask("NodeB");
            playerCamera = GameObject.Find("TeamA_Camera").GetComponent<Camera>();
        }
        else
        {
            spawningMask = LayerMask.GetMask("NodeB");
            spellMask = LayerMask.GetMask("NodeA");
            playerCamera = GameObject.Find("TeamB_Camera").GetComponent<Camera>();
        }
    }
    public void ShootRaycast(Camera camera, LayerMask mask)
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
