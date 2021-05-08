using System;
using UnityEngine;

[Serializable]
public enum SpellName
{
    MeteorBlast,
    IceStorm,
    HolyShield,
    RighteousStrike,
    Teleport,
    Break,
    ArrowStorm
}
public abstract class ChampionSpell : ScriptableObject
{
    public SpellStats spellStats;
    public SpellEffect spellEffect;

    public abstract void CastSpell(User user);
    public abstract void AimSpell(UserRaycast raycast);
    public abstract void UseSpell(GameObject spellIndicator);

    public abstract void AnimateSpellVisualEffect(Vector3 position);
}

