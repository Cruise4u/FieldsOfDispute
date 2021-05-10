using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PlayerCanvas : UserCanvas
{
    public GameObject spawnUnitGO;
    public override void WriteMessageForUser(string message)
    {
        messagePanelGO.GetComponent<TextMeshProUGUI>().text = message;
    }
    public void DisplaySpawnUnitIconOnUI()
    {
        var poolIcon = gameObject.GetComponent<PoolController>().currentPool.poolIcon;
        spawnUnitGO.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = poolIcon;
    }
    public void DisplaySpawnNumberOnUI(int number)
    {
        spawnUnitGO.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "x" + number.ToString();
    }
}
