using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum PlayerTeam
{
    TeamA,
    TeamB,
}

public enum PoolName
{
    KnightPool,
    ArcherPool,
    MagePool,
}

public class PlayerController : MonoBehaviour
{
    public PlayerTeam playerTeam;
    public UnitPoolManager unitPoolManager;
    public int[] borderNode;
    public bool isPlayerTurn;


    public void Init(FieldGrid fieldGrid)
    {
        if(playerTeam == PlayerTeam.TeamA)
        {
            borderNode = fieldGrid.gridData.borderNodesId_A;
        }
        else
        {
            borderNode = fieldGrid.gridData.borderNodesId_B;
        }
    }

    public void ChooseAvailableNodeToSpawn(PoolName poolName)
    {
        if(PlayerRaycast.hittedObject != null)
        {
            if(PlayerRaycast.hittedObject.TryGetComponent(out FieldGridNode node))
            {
                if (node.unitStationed == null)
                {
                    unitPoolManager.SpawnFromPool(node.unitStationedTransform.position, poolName);
                    node.unitStationed = unitPoolManager.lastPrefabInstantiated;
                    node.unitStationed.tag = playerTeam.ToString();
                    unitPoolManager.lastPrefabInstantiated.GetComponent<UnitController>().currentNode = node;
                }
            }
        }
    }

    public void SwapUnits()
    {

    }

    public void CastSpell()
    {

    }


}


