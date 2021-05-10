using System;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ChampionMana : MonoBehaviour,IObserver
{
    public GameObject manaBarGO;
    public int maxManaPoints;
    public int currentManaPoints;

    public void Init()
    {
        maxManaPoints = 3;
        currentManaPoints = maxManaPoints;
        UpdateManaBar(currentManaPoints);
    }

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

    public void UpdateManaBar(float value)
    {
        manaBarGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

    public void GetNotified(float value)
    {
        UpdateManaBar(value);
    }
}

