using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Spell/Stats")]
public class SpellStats : ScriptableObject
{
    public int spellId;
    public GameObject spellPrefab;
    public GameObject spellIndicator;
    public int spellPower;
    public int spellCost;
    public int spellCD;
}
