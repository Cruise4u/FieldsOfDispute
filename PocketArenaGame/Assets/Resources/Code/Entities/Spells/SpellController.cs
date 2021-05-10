using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public Dictionary<int, Spell> spellDictionary;
    public List<Spell> spellList;
    public GameObject currentSpellIndicator;
    public SpellCooldown spellCooldown;
    public Spell currentSpell;
    public bool isSpellBeingAimed;
    public bool isSpellCastable;

    public void Init()
    {
        spellDictionary = new Dictionary<int, Spell>();
        spellCooldown.cooldownList = new List<float>();
        spellCooldown.ObserverList = new List<IObserver>();
        AddSpellEntryToDictionary();
        spellCooldown.AddCooldownsToList(spellDictionary);
        spellCooldown.SetSpellUICostForAllButtons(spellList);
        spellCooldown.Init();
    }
    public void AddSpellEntryToDictionary()
    {
        for (int i = 0; i < spellList.Count; i++)
        {
            spellDictionary.Add(spellList[i].spellStats.spellId, spellList[i]);
        }
    }
    public void SetCurrentSpell(int id)
    {
        currentSpell = spellList[id];
        currentSpellIndicator = Instantiate(currentSpell.spellStats.spellIndicator, new Vector3(100, 100, 100), Quaternion.identity);
    }
    public void AimSpecificSpell(Spell spell)
    {
        var userRaycast = gameObject.GetComponentInParent<UserRaycast>();
        spell.AimSpell(userRaycast);
    }
    public void CastSpecificSpell(Spell spell)
    {
        var user = gameObject.transform.parent.GetComponent<User>();
        spell.CastSpell(user);
    }
    public void EnableIndicator(int index)
    {
        var user = gameObject.GetComponentInParent<User>();
        if (user.isPlayerTurn == true && isSpellCastable == true)
        {
            currentSpell = spellDictionary[index];
            currentSpellIndicator = Instantiate(currentSpell.spellStats.spellIndicator);
        }
    }
    public void DisableIndicator()
    {
        Destroy(currentSpellIndicator);
        isSpellBeingAimed = false;
    }
    public void ToggleSpellAim()
    {
        if (isSpellBeingAimed == true)
        {
            isSpellBeingAimed = false;
        }
        else
        {
            isSpellBeingAimed = true;
        }
    }
}

