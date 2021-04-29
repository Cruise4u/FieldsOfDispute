using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static RaycastHit playerCastHit;
    public static Ray playerRay;
    public ObjectPool objectPool;
    public PlayerRaycast playerRaycast;

    public void ChooseAvailableNodeToSpawn(PoolName poolName)
    {
            if(IsObjectHittedOfTypeNode(PlayerRaycast.hittedObject))
            {
                var gridNode = PlayerRaycast.hittedObject.GetComponent<FieldGridNode>();
                if(IsNodeNotPopulated(gridNode))
                {
                    SpawnUnit(poolName,gridNode);
                    gridNode.unitStationed = PlayerRaycast.hittedObject;
                    PlayerRaycast.hittedObject.GetComponent<UnitController>().nodeBelowGO = gridNode;
                }
            }
    }

    public void SpawnUnit(PoolName poolName,FieldGridNode node)
    {
        objectPool.SpawnPrefab(poolName,node.unitStationedTransform.position);
    }

    public bool IsObjectHittedOfTypeNode(GameObject obj)
    {
        bool condition;
        if(obj!= null)
        {
            Debug.Log("Is null!");
            if (obj.TryGetComponent(out FieldGridNode node))
            {
                condition = true;
                Debug.Log("Condition is " + condition);
            }
            else
            {
                condition = false;
                Debug.Log("Condition is " + condition);
            }
        }
        else
        {
            condition = false;
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


