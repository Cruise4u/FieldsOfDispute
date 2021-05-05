using System;
using UnityEngine;

public abstract class ChampionSpell : ScriptableObject
{
    public SpellStats spellStats;
    public SpellEffect spellEffect;

    public abstract void CastSpell(Player player);
    public abstract void AimSpell(Player player, Camera camera, LayerMask mask);

    public abstract void UseSpell(GameObject spellShape);
}

