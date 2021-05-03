using System;

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

