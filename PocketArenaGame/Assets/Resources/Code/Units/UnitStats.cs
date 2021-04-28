using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;

public class UnitStats : MonoBehaviour
{
    public EntitiyStatsData statsData;
    //[NonSerialized]
    public int unitHealthPoints;
    public int unitMovementPoints;
    public int unitAttackPoints;
    
    public void OnEnable()
    {

    }
}

public class UnitSpawner
{
    
}



public class TurnManager
{
    public FieldGrid fieldGrid;
    public ObjectPool teamPool;







}