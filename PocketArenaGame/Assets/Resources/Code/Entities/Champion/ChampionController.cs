using System;
using UnityEngine;
using System.Linq;

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
        for (int i = 0; i < spellController.spellList.Count; i++)
        {
            if(spellController.spellList[i].spellStats.spellCost > manaStats.currentManaPoints)
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

    public bool HasManaToCastSpell(ChampionSpell spell)
    {
        if (spell.spellStats.spellCost > manaStats.currentManaPoints)
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
        manaStats.currentManaPoints -= cost;
    }
}
