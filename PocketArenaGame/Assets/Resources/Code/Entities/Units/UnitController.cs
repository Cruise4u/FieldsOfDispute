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
    public bool IsPossibleToMoveForward(FieldGrid fieldGrid)
    {
        bool condition;
        var forwardCoordinates = currentNode.coordinates + new Vector2(1, 0);
        forwardNode = fieldGrid.nodeCoordinatesDictionary[forwardCoordinates].GetComponent<FieldGridNode>();
        if (forwardNode.unitStationed == null)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public void TriggerMovementOrder()
    {
        CustomEvent.Trigger(gameObject,"OnMoveForwardEvent");
    }
    public void MoveUnitForward()
    {
        transform.DOMove(forwardNode.unitStationedTransform.position, 1.0f);
    }
    public void MoveUnitToNode(FieldGridNode node)
    {
        transform.DOMove(node.unitStationedTransform.position, 1.0f);
        currentNode = node;
    }
    public void AttackChampion(UnitStats unitStats, ChampionController enemyChampion)
    {
        enemyChampion.championHealth.currentHealthPoints -= unitStats.unitAttackPoints;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage Sucessfull!");
        unitStats.unitCurrentHealthPoints -= damage;
        unitStats.unitUI.SetUIPoints(unitStats.unitUI.healthUIGO, unitStats.unitCurrentHealthPoints);
        if(unitStats.unitCurrentHealthPoints < 1)
        {
            Die(1.5f);
        }
    }
    public void Die(float timer)
    {
        Destroy(gameObject, timer);
    }
    public void RecalculatePositionOnGrid()
    {
        var tempDoubleFwdNode = forwardNode.coordinates + new Vector2(1, 0);
        currentNode.coordinates = forwardNode.coordinates;
        forwardNode.coordinates = tempDoubleFwdNode;
    }
}
