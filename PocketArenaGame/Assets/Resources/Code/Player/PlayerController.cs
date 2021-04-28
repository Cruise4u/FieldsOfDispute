using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static RaycastHit playerCastHit;
    public static Ray playerRay;
    public ObjectPool objectPool;
    public PlayerRaycast playerRaycast;

    public void SpawnUnitOnAvailableNode(PoolName poolName)
    {
            if(IsObjectHittedOfTypeNode(PlayerRaycast.hittedObject))
            {
                var gridNode = PlayerRaycast.hittedObject.GetComponent<FieldGridNode>();
                if(IsNodeNotPopulated(gridNode))
                {
                StationUnitOnNode(poolName,gridNode);
                }
            }
    }

    public void StationUnitOnNode(PoolName poolName,FieldGridNode node)
    {
        objectPool.SpawnPrefab(poolName,node.unitStationedTransform.position);
    }

    public bool IsObjectHittedOfTypeNode(GameObject node)
    {
        bool condition;
        if (node.TryGetComponent(out FieldGridNode gridNode))
        {
            condition = true;
        }
        else
        {
            condition = true;
        }
        return condition;
    }

    public bool IsNodeNotPopulated(FieldGridNode node)
    {
        bool condition;
        if(node.unitStationed == null)
        {
            condition = true; 
            Debug.Log("Node Available to Populate!");
        }
        else
        {
            condition = false;
        }
        return condition;
    }

}


