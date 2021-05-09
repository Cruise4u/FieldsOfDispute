using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour,ISubject
{
    public GameObject currentSpellIndicator;
    public Spell currentSpell;
    public List<Spell> spellList;
    public List<SpellButton> spellUIList;
    public Dictionary<string, Spell> spellDictionary;
    public Dictionary<string, float> cooldownDictionary;
    public List<IObserver> observerList { get => ObserverList; }
    public List<IObserver> ObserverList;
    public bool isSpellBeingAimed;
    public bool isSpellCastable;

    public bool IsSpellOnCD(string spellName)
    {
        bool condition;
        if (spellDictionary[spellName].spellStats.spellCD > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public void Init()
    {
        spellDictionary = new Dictionary<string, Spell>();
        cooldownDictionary = new Dictionary<string, float>();
        ObserverList = new List<IObserver>();
        AddEntriesToDictionaries();
        AttachObserver();

    }
    public void SetCurrentSpell(string spellName)
    {
        currentSpell = spellDictionary[spellName];
        currentSpellIndicator = Instantiate(currentSpell.spellStats.spellIndicator,new Vector3(100,100,100),Quaternion.identity);
    }
    public void AddEntriesToDictionaries()
    {
        foreach(Spell spell in spellList)
        {
            Debug.Log(spell);
            spellDictionary.Add(spell.spellStats.spellName, spell);
            cooldownDictionary.Add(spell.spellStats.spellName, 0);
        }
    }
    public void SetCooldownToMaximum(GameObject uiButtonGO, string spellName)
    {
        var mana = gameObject.GetComponent<ChampionController>().championMana;
        cooldownDictionary[spellName] = spellDictionary[spellName].spellStats.spellCD;
        NotifyObserver(, cooldownDictionary[spellName]);
    }
    public void ReduceCooldown(string spellName,float amount)
    {
        var currentCooldown = cooldownDictionary[spellName];
        currentCooldown -= amount;
        NotifyObserver(spellList[index],currentCooldown);
    }
    public void ResetAllCooldownsOnBegin()
    {
        foreach(Spell spell in spellList)
        {
            spell.spellStats.spellCD = 0;
            NotifyObserver(0);
        }
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
    public void EnableIndicator(string spellName)
    {
        var user = gameObject.GetComponentInParent<User>();
        if (user.isPlayerTurn == true && isSpellCastable == true)
        {
            currentSpell = spellDictionary[spellName];
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

    #region Observer Pattern

    public void AttachObserver()
    {
        foreach(SpellButton button in spellUIList)
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

