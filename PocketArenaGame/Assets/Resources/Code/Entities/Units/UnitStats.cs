using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class UnitStats : MonoBehaviour
{
    public EntitiyStatsData statsData;
    public int unitMaxHealthPoints;
    public int unitCurrentHealthPoints;
    public int unitMovementPoints;
    public int unitAttackPoints;

    public UnitController unitController;
    public List<SpellEffect> effectsOnUnitList;

    public void Init()
    {
        unitCurrentHealthPoints = statsData.healthPoints;
        unitMovementPoints = statsData.movementPoints;
        unitAttackPoints = statsData.attackPoints;
    }

    public void RemoveUnusedEffects()
    {
        foreach(SpellEffect effect in effectsOnUnitList)
        {
            if(effect.isActive != true)
            {
                effect.RemoveEffect(gameObject);
                effectsOnUnitList.Remove(effect);
            }
        }
    }

    public void TriggerEffects()
    {
        foreach(SpellEffect effect in effectsOnUnitList)
        {
            if(effect.thisEffectType == SpellEffect.EffectType.Instant)
            {
                effect.ApplyEffect(gameObject);
            }
        }
    }
}
