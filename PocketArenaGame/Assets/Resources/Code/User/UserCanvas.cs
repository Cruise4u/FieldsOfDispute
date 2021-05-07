using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UserCanvas : MonoBehaviour
{
    public Canvas canvas;
    public GameObject messagePanelGO;
    public GameObject spawnUnitGO;

    public List<GameObject> spellUIList;

    public virtual void Init()
    {

    }

    public virtual void WriteMessageForUser(string message)
    {

    }

    public virtual void DisplaySpawnUnitIconOnUI()
    {
        var poolIcon = gameObject.GetComponent<PoolController>().currentPool.poolIcon;
        spawnUnitGO.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = poolIcon;
    }

    public virtual void DisplaySpawnNumberOnUI(int number)
    {
        spawnUnitGO.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "x" + number.ToString();
    }

}