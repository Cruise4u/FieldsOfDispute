using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{
    public EntitiyStatsData statsData;
    //[NonSerialized]
    public int unitHealthPoints;
    public int unitMovementPoints;
    public int unitAttackPoints;
    
    public void OnEnable()
    {

    }

    public void SetUnitToNodePosition()
    {

    }

}

public class TurnManager
{
    public FieldGrid fieldGrid;
    public ObjectPool teamPool;







}