using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell/Effects/Frozen")]
public class FrostEffect : SpellEffect
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