using System;
using UnityEngine;
using DG.Tweening;

public class UnitController : MonoBehaviour
{
    public PlayerController playerController;
    public UnitStats unitStats;
    public FieldGridNode currentNode;
    public FieldGridNode forwardNode;

    public void SetComponentsValuesOnBolt(FieldGrid fieldGrid)
    {
        fieldGrid = FindObjectOfType<FieldGrid>();
    }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        foreach(PlayerController controller in FindObjectsOfType<PlayerController>())
        {
            if(controller.playerTeam.ToString() == gameObject.tag)
            {
                playerController = controller;
                Debug.Log(playerController);
            }
        }

    }

    public bool IsCurrentNodeOnBorder(int[] borderNode)
    {
        bool condition = false;
        for (int i = 0; i < borderNode.Length; i++)
        {
            if (currentNode.nodeID != borderNode[i])
            {
                condition = true;
            }
            else
            {
                condition = false;
                break;
            }
        }
        return condition;
    }

    public bool IsPossibleToMoveForward(FieldGrid fieldGrid)
    {
        bool condition;
        Debug.Log(fieldGrid);
        forwardNode = fieldGrid.nodeList[currentNode.nodeID + 1].GetComponent<FieldGridNode>();
        if(forwardNode.unitStationed == null)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }

    public void MoveUnitForward()
    {
        transform.DOMove(forwardNode.unitStationedTransform.position, 1.0f);
    }

    public void AttackChampion(UnitStats unitStats,Champion enemyChampion)
    {
        enemyChampion.championsHealth -= unitStats.unitAttackPoints;
    }

    public void RecalculatePositionOnGrid()
    {
        var tempDoubleFwdNode = forwardNode.nodeID + 1;
        currentNode.nodeID = forwardNode.nodeID;
        forwardNode.nodeID = tempDoubleFwdNode;
    }
}
