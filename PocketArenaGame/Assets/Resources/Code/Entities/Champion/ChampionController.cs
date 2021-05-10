using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ChampionController : MonoBehaviour, ISubject
{
    public Team playerTeam;
    public ChampionHealth championHealth;
    public ChampionMana championMana;
    public SpellController spellController;

    public List<IObserver> observerList { get => ObserverList; }
    public List<IObserver> ObserverList;

    public void Init()
    {
        championHealth.Init();
        championMana.Init();
        spellController.Init();
    }

    public bool IsChampionAlive()
    {
        if (championHealth.currentHealthPoints > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsManaDepleted()
    {
        bool condition = false;
        bool[] conditionArray;
        var spellController = gameObject.GetComponent<SpellController>();
        conditionArray = new bool[spellController.spellList.Count];
        for (int i = 0; i < spellController.spellList.Count; i++)
        {
            if(spellController.spellList[i].spellStats.spellCost > championMana.currentManaPoints)
            {
                conditionArray[i] = true;
            }
            else
            {
                conditionArray[i] = false;
            }
        }
        condition = conditionArray.All(boolean => boolean == true);
        return condition;
    }

    public bool HasManaToCastSpell(Spell spell)
    {
        if (spell.spellStats.spellCost > championMana.currentManaPoints)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ConsumeManaPoint(int cost)
    {
        championMana.currentManaPoints -= cost;
        NotifyObserver(championMana,championMana.currentManaPoints);
    }

    public void TakeDamage(int damage)
    {
        championHealth.currentHealthPoints -= damage;
        NotifyObserver(championHealth, championHealth.currentHealthPoints);
    }

    public void AttachObserver()
    {
        ObserverList.Add(championHealth);
        ObserverList.Add(championMana);
    }

    public void RemoveObserver()
    {
        throw new NotImplementedException();
    }

    public void NotifyObserver(IObserver observer, float value)
    {
        observer.GetNotified(value);
    }
}
