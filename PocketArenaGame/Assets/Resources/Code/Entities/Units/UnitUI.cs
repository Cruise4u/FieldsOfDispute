using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public GameObject healthUIGO;
    public GameObject attackUIGO;
    public GameObject movementUIGO;

    public void SetUIPoints(GameObject go,int points)
    {
        go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = points.ToString();
    }

    public void ChooseNextPreSpawnUnit()
    {

    }
}
