using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell/Effects/Burn")]
public class BurnEffect : SpellEffect
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

