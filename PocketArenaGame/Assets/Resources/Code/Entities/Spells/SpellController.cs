using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour,ISpellSubject
{
    public GameObject currentSpellIndicator;
    public ChampionSpell currentSpell;
    public List<ChampionSpell> spellList;
    public List<SpellButton> spellUIList;
    public Dictionary<SpellName, ChampionSpell> spellDictionary;
    public Dictionary<SpellName, float> cooldownDictionary;

    public List<ISpellObserver> observerList { get => ObserverList; }
    public List<ISpellObserver> ObserverList;

    public bool isSpellBeingAimed;
    public bool isSpellCastable;

    public void Init()
    {
        spellDictionary = new Dictionary<SpellName, ChampionSpell>();
        cooldownDictionary = new Dictionary<SpellName, float>();
        ObserverList = new List<ISpellObserver>();
        AddEntriesToDictionaries();
        AttachObserver();
    }

    public void SetCurrentSpell(SpellName spellName)
    {
        currentSpell = spellDictionary[spellName];
    }

    public bool IsSpellOnCD(SpellName spellName)
    {
        bool condition;
        if(spellDictionary[spellName].spellStats.spellCD > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public void AddEntriesToDictionaries()
    {
        foreach(ChampionSpell spell in spellList)
        {
            spellDictionary.Add(spell.spellStats.spellName, spell);
            cooldownDictionary.Add(spell.spellStats.spellName, 0);
        }
    }
    public void SetCooldownToMaximum(SpellName spellName)
    {
        cooldownDictionary[spellName] = spellDictionary[spellName].spellStats.spellCD;
        NotifyObserver(cooldownDictionary[spellName]);
    }
    public void ReduceCooldown(SpellName spellName,float amount)
    {
        var currentCooldown = cooldownDictionary[spellName];
        currentCooldown -= amount;
        NotifyObserver(currentCooldown);
    }
    public void ResetAllCooldownsOnBegin()
    {
        foreach(ChampionSpell spell in spellList)
        {
            spell.spellStats.spellCD = 0;
            NotifyObserver(0);
        }
    }
    public void AimSpecificSpell(ChampionSpell spell)
    {
        var userRaycast = gameObject.GetComponentInParent<UserRaycast>();
        spell.AimSpell(userRaycast);
    }
    public void CastSpecificSpell(ChampionSpell spell)
    {
        var user = gameObject.transform.parent.GetComponent<User>();
        spell.CastSpell(user);
    }
    public void EnableIndicator(int spellId)
    {
        var user = gameObject.GetComponentInParent<User>();
        if (user.isPlayerTurn == true && isSpellCastable == true)
        {
            currentSpell = spellDictionary[(SpellName)spellId];
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
    public void AttachObserver()
    {
        foreach(SpellButton button in spellUIList)
        {
                Debug.Log(button);
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
    public void NotifyObserver(float cooldown)
    {
        foreach(ISpellObserver observer in observerList)
        {
            observer.GetNotified(cooldown);
        }
    }
}
