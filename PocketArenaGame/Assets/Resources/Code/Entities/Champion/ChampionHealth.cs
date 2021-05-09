using System;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ChampionHealth : MonoBehaviour,IObserver
{
    public GameObject healthBarGO;
    public int maxHealthPoints;
    public int currentHealthPoints;

    public void GetNotified(float value)
    {
        UpdateHealthBar(value);
    }

    public void Init()
    {
        maxHealthPoints = 20;
        currentHealthPoints = maxHealthPoints;
        UpdateHealthBar(currentHealthPoints);
    }

    public void UpdateHealthBar(float value)
    {
        healthBarGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

}
