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

}