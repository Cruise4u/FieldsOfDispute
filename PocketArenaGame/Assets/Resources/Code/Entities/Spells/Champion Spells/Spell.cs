using System;
using UnityEngine;


public abstract class Spell : ScriptableObject
{
    public SpellStats spellStats;
    public SpellEffect spellEffect;

    public abstract void CastSpell(User user);
    public abstract void AimSpell(UserRaycast raycast);
    public abstract void UseSpell(GameObject spellIndicator);

    public abstract void AnimateSpellVisualEffect(Vector3 position);
}

