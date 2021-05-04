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
    public void SetPreSpawningUnit(string poolName)
    {
        var poolController = gameObject.GetComponent<PlayerController>().poolController;
        poolController.currentPool = poolController.poolDictionary[poolName];
        var instance = poolController.currentPool.poolStack.Peek();
        Debug.Log(instance);
        poolController.SpawnFromPool(new Vector3(0,0,0));
        visualizationUnit = instance;
    }
    public void UpdatePreSpawningUnit(Camera camera,LayerMask mask)
    {
        ShootRaycast(camera, mask);
        if (hittedObject != null)
        {
            if (hittedObject.tag == "SpawnNode" && hittedObject.GetComponent<FieldGridNode>().unitStationed == null)
            {
                visualizationUnit.transform.position = hittedObject.GetComponent<FieldGridNode>().unitStationedTransform.position;
            }
        }
    }
    public void StopVisualization(GameObject instance)
    {
        Destroy(instance);
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
