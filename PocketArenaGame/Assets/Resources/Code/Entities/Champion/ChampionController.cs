using System;
using UnityEngine;

public class ChampionController : MonoBehaviour
{
    public Team playerTeam;
    public ChampionHealth championHealth;
    public ManaStats manaStats;
    public SpellController spellController;

    public void Init()
    {
        championHealth.Init();
        manaStats.Init();
        spellController.Init();
    }

    public bool IsManaDepleted()
    {
        bool condition = false;
        bool[] conditionArray;
        var spellController = gameObject.GetComponent<SpellController>();
        conditionArray = new bool[spellController.spellList.Count];
        Debug.Log(conditionArray.Length);
        Debug.Log(spellController.spellList.Count);
        for (int i = 0; i < spellController.spellList.Count; i++)
        {
            if(spellController.spellList[i].spellStats.spellCost > manaStats.currentManaPoints)
            {
                Debug.Log("Spell Cost is:" + spellController.spellList[i].spellStats.spellCost);
                Debug.Log("Mana Points are:" + manaStats.currentManaPoints);
                conditionArray[i] = true;
            }
            else
            {
                conditionArray[i] = false;
            }
        }
        foreach(bool boolean in conditionArray)
        {
            if(boolean == true)
            {
                condition = true;
            }
        }
        return condition;
    }

    public void ConsumeManaPoint(int cost)
    {
        manaStats.currentManaPoints -= cost;
    }

}
