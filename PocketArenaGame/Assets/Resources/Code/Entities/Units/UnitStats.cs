using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;

public class UnitStats : MonoBehaviour
{
    public EntitiyStatsData statsData;
    [NonSerialized]
    public int unitHealthPoints;
    [NonSerialized]
    public int unitMovementPoints;
    [NonSerialized]
    public int unitAttackPoints;

    public UnitController unitController;

    public void Init()
    {
        unitHealthPoints = statsData.healthPoints;
        unitMovementPoints = statsData.movementPoints;
        unitAttackPoints = statsData.attackPoints;
    }
}
