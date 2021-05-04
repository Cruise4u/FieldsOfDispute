using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public bool isSpellActive;
    public List<Spell> spellList;
    public LayerMask enemyFieldMask;

    public void ActivateSpell(int index)
    {
        spellList[index].spellStats.spellPrefab.SetActive(true);
    }

    public void AimSpellOnField(int index,Camera camera,LayerMask mask,PlayerTeam team)
    {
        var grid = FindObjectOfType<FieldGrid>();
        //spellList[index].AimSpell(camera, mask,team);
    }


}
