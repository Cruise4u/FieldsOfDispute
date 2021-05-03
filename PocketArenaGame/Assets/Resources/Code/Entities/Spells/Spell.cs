using System;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    public enum SpellType
    {
        Line,
        Area,
        Custom,
    }
    public SpellType spellType;
    public SpellStats spellStats;
    public SpellEffect spellEffect;

    public virtual void CastSpell(LayerMask mask)
    {

    }

    public virtual void AimSpell(FieldGrid grid,Camera camera, LayerMask mask)
    {

    }

    public virtual void VisualizeSpellOnGrid(FieldGrid grid,GameObject simulatedHit,GameObject spellPrefab)
    {

    }

 }
