using System;
using UnityEngine;

[System.Serializable]
public class ChampionHealth : MonoBehaviour
{
    public int maxHealthPoints;
    public int currentHealthPoints;

    public void Init()
    {
        maxHealthPoints = 20;
        currentHealthPoints = maxHealthPoints;
    }
}
