using System;
using UnityEngine;

public abstract class ChampionSpell : ScriptableObject
{
    public SpellStats spellStats;
    public SpellEffect spellEffect;

    public abstract void CastSpell(User user);
    public abstract void AimSpell(UserRaycast raycast);
    public abstract void UseSpell(GameObject spellIndicator);
}

