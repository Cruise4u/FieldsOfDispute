using System;
using UnityEngine;

public abstract class SpellEffect : ScriptableObject
{
    public enum EffectType
    {
        Buff,
        Debuff,
        Instant,
    }
    public EffectType thisEffectType;
    public int effectPower;
    public float effectMaxDuration;
    public bool isActive;

    public abstract void ApplyEffect(GameObject target);
    public abstract void RemoveEffect(GameObject target);
    public virtual bool CheckIfEffectIsActive(float duration)
    {
        bool condition;
        if(duration != 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
}

[CreateAssetMenu(menuName ="Spell/Effects/Burn")]
public class BurningEffect : SpellEffect
{
    public float effectTempDuration;

    public override void ApplyEffect(GameObject target)
    {
        target.GetComponent<UnitStats>().unitCurrentHealthPoints -= effectPower;
    }

    public override void RemoveEffect(GameObject target)
    {
        //Does nothing..
    }
}

[CreateAssetMenu(menuName = "Spell/Effects/Frozen")]
public class FreezingEffect : SpellEffect
{
    public float effectTempDuration;

    public override void ApplyEffect(GameObject target)
    {
        target.GetComponent<UnitController>().unitStats.unitMovementPoints -= effectPower;
    }

    public override void RemoveEffect(GameObject target)
    {
        target.GetComponent<UnitController>().unitStats.unitMovementPoints += effectPower;
    }
}