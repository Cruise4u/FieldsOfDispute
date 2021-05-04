using System;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    public SpellStats spellStats;
    public SpellEffect spellEffect;

    public virtual void CastSpell(GameObject spellShape)
    {

    }

    public virtual void AimSpell(GameObject instance,PlayerController controller,Camera camera, LayerMask mask)
    {

    }

}
