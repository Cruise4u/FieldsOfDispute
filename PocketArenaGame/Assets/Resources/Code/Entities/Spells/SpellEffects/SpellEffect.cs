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

