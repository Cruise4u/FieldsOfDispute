using System;
using UnityEngine;
using DG.Tweening;
using Bolt;

public class UnitController : MonoBehaviour
{
    public UnitStats unitStats;
    public FieldGridNode currentNode;
    public FieldGridNode forwardNode;

    public void Init()
    {
        unitStats.Init();
    }

    public bool IsCurrentNodeOnBorder(LayerMask borderMask)
    {
        bool condition = false;
        if (currentNode.gameObject.layer != borderMask)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public bool IsPossibleToMoveForward()
    {
        var grid = FindObjectOfType<FieldGrid>();
        var forwardCoordinates = currentNode.coordinates + new Vector2(1, 0);
        Debug.Log("forwardCoordintes!");
        forwardNode = grid.nodeCoordinatesDictionary[forwardCoordinates].GetComponent<FieldGridNode>();
        if (forwardNode.unitStationed == null)
        {
            currentNode.unitStationedTransform = null;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TriggerMovementOrder()
    {
        CustomEvent.Trigger(gameObject, "OnMoveForwardEvent", true);
    }
    public void MoveUnitForward()
    {
        transform.DOMove(forwardNode.unitStationedTransform.position, 1.0f);
    }
    public void MoveUnitToNode(FieldGridNode node)
    {
        transform.DOMove(node.unitStationedTransform.position, 1.25f);
    }
    public void AttackChampion(UnitStats unitStats, ChampionController enemyChampion)
    {
        enemyChampion.championHealth.currentHealthPoints -= unitStats.unitAttackPoints;
    }
    public void TakeDamage(int damage)
    {
        unitStats.unitCurrentHealthPoints -= damage;
        unitStats.unitUI.SetUIPoints(unitStats.unitUI.healthUIGO, unitStats.unitCurrentHealthPoints);
        if(unitStats.unitCurrentHealthPoints < 1)
        {
            Die(3.0f);
        }
    }
    public void Die(float timer)
    {
        Destroy(gameObject, timer);
    }
    public void RecalculatePositionOnGrid()
    {
        var grid = FindObjectOfType<FieldGrid>();
        var tempDoubleFwdNode = forwardNode.coordinates + new Vector2(1, 0);
        currentNode.coordinates = forwardNode.coordinates;
        currentNode.unitStationedTransform = null;
        forwardNode = grid.nodeCoordinatesDictionary[tempDoubleFwdNode].GetComponent<FieldGridNode>();
    }
}
