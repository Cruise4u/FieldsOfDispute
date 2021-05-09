using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public GameObject currentSpellIndicator;
    public SpellCooldown spellCooldown;
    public Spell currentSpell;
    public bool isSpellBeingAimed;
    public bool isSpellCastable;
    public List<Spell> spellList;
    public Dictionary<int, Spell> spellDictionary;

    public void Init()
    {
        spellDictionary = new Dictionary<int, Spell>();
        spellCooldown.cooldownDictionary = new Dictionary<int, float>();
        spellCooldown.ObserverList = new List<IObserver>();
        spellCooldown.AddEntriesToDictionaries(spellList,spellDictionary);
        spellCooldown.ResetAllCooldownsOnBegin(spellList);
        spellCooldown.AttachObserver();
    }
    public void SetCurrentSpell(Spell spell)
    {
        currentSpell = spell;
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

public class SpellCooldown : MonoBehaviour,ISubject
{
    public List<SpellButton> spellUIList;
    public Dictionary<int, float> cooldownDictionary;
    public List<IObserver> observerList { get => ObserverList; }
    public List<IObserver> ObserverList;

    public void Init()
    {
        AttachObserver();
    }

    public bool IsSpellOnCD(int index, Spell spell)
    {
        bool condition;
        if (spell.spellStats.spellCD > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public void AddEntriesToDictionaries(List<Spell> list ,Dictionary<int,Spell> dictionary)
    {
        foreach (Spell spell in list)
        {
            dictionary.Add(spell.spellStats.spellId, spell);
            cooldownDictionary.Add(spell.spellStats.spellId, 0);
        }
    }
    public void SetCooldownToMaximum(int index, Dictionary<int,Spell> dictionary)
    {
        var mana = gameObject.GetComponent<ChampionController>().championMana;
        cooldownDictionary[index] = dictionary[index].spellStats.spellCD;
        NotifyObserver(spellUIList[index], cooldownDictionary[index]);
    }
    public void ReduceCooldown(int index, float amount)
    {
        var currentCooldown = cooldownDictionary[index];
        currentCooldown -= amount;
        NotifyObserver(spellUIList[index], currentCooldown);
    }
    public void ResetAllCooldownsOnBegin(List<Spell> list)
    {
        for(int i = 0; i < spellUIList.Count; i++)
        {
            list[i].spellStats.spellCD = 0;
            NotifyObserver(spellUIList[0], 0);
        }
    }

    #region Observer Pattern

    public void AttachObserver()
    {
        foreach (SpellButton button in spellUIList)
        {
            ObserverList.Add(button);
        }
    }
    public void RemoveObserver()
    {
        foreach (SpellButton button in spellUIList)
        {
            observerList.Remove(button);
        }
    }
    public void NotifyObserver(IObserver observer, float cooldown)
    {
        observer.GetNotified(cooldown);
    }
    #endregion
}