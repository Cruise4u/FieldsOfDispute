using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCooldown : MonoBehaviour, ISubject
{
    public List<SpellButton> spellButtonList;
    public List<float> cooldownList;
    public List<IObserver> observerList { get => ObserverList; }
    
    public List<IObserver> ObserverList;
    public void Init()
    {
        AttachObserver();
    }
    public bool IsSpellOnCD(int index)
    {
        bool condition;
        if (cooldownList[index] > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public void AddCooldownsToList(Dictionary<int,Spell> dictionary)
    {
        if(gameObject.GetComponentInParent<User>().team == Team.A)
        {
            for (int i = 0; i < dictionary.Count; i++)
            {
                cooldownList.Add(0);
                NotifyObserver(spellButtonList[i], 0);
            }
        }
        else
        {
            for (int i = 0; i < dictionary.Count; i++)
            {
                cooldownList.Add(0);
            }
        }
    }
    public void SetCooldownToMaximum(int index, Dictionary<int, Spell> dictionary)
    {
        var mana = gameObject.GetComponent<ChampionController>().championMana;
        cooldownList[index] = dictionary[index].spellStats.spellCD;
        NotifyObserver(spellButtonList[index], cooldownList[index]);
    }
    public void ReduceCooldown(int index, float amount)
    {
        var currentCooldown = cooldownList[index];
        currentCooldown -= amount;
        NotifyObserver(spellButtonList[index], currentCooldown);
    }
    public void UpdateCooldownText(int index, float amount)
    {
        var currentCooldown = cooldownList[index];
        currentCooldown -= amount;
        NotifyObserver(spellButtonList[index], currentCooldown);
    }
    public void SetSpellUICostForAllButtons(List<Spell> spellList)
    {
        for(int i = 0; i < spellButtonList.Count; i++)
        {
            spellButtonList[i].SetSpellUICost(spellList[i].spellStats.spellCost);
        }
    }

    #region Observer Pattern
    public void AttachObserver()
    {
        foreach (SpellButton button in spellButtonList)
        {
            ObserverList.Add(button);
            NotifyObserver(button, 0);
        }
    }
    public void RemoveObserver()
    {
        foreach (SpellButton button in spellButtonList)
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