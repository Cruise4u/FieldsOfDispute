using System;
using UnityEngine;

public class ChampionController : MonoBehaviour
{
    public ChampionStats championStats;
    public ManaStats manaStats;
    public SpellController spellController;

    public void Init()
    {
        championStats = new ChampionStats();
        manaStats = new ManaStats();
    }
}

[System.Serializable]
public class ManaStats
{
    public int maxManaPoints;
    public int currentManaPoints;

    public void ResetManaPoints(int turnNumber)
    {
        if (turnNumber != 1)
        {
            currentManaPoints = maxManaPoints;
        }
    }

    public void IncreaseMaxManaPoints(int turnNumber)
    {
        if (turnNumber != 1)
        {
            if (maxManaPoints != 10)
            {
                maxManaPoints += 1;
            }
        }
    }

    public void Init()
    {
        maxManaPoints = 3;
        currentManaPoints = maxManaPoints;
    }
}

[System.Serializable]
public class ChampionStats
{
    public int maxHealthPoints;
    public int currentHealthPoints;
    public int attackPoints;

    public void Init()
    {
        maxHealthPoints = 20;
        currentHealthPoints = maxHealthPoints;
    }
}