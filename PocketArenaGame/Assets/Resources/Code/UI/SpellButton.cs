using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour,IObserver
{
    public int buttonID;
    public GameObject UICooldownFiller;
    public GameObject UICDValue;
    public GameObject spellCostGO;

    public void ChangeCooldownValue(float value)
    {
        if((value) == 0)
        {
            UICDValue.GetComponent<TextMeshProUGUI>().text = "";
        }
        else
        {
            UICDValue.GetComponent<TextMeshProUGUI>().text = value.ToString();
        }
    }

    public void ChangeCooldownShaderFiller(float value)
   {
        Debug.Log(value);
        UICooldownFiller.GetComponent<Image>().fillAmount = (value / 1);
   }

    public void GetNotified(float value)
    {
        Debug.Log(value);
        ChangeCooldownValue(value);
        ChangeCooldownShaderFiller(value);
    }

    public void SetSpellUICost(int value)
    {
        spellCostGO.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

}
