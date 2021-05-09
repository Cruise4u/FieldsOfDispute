using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour,IObserver
{
    public string spellButtonName;
    public float UICooldownValue;
    public GameObject UICooldownFiller;
    public GameObject UICDValue;

    public void ChangeCooldownValue(float value)
    {
        UICDValue.GetComponent<TextMeshProUGUI>().text = (UICooldownValue - value).ToString();
    }

    public void ChangeCooldownShaderFiller()
   {
        UICooldownFiller.GetComponent<Image>().fillAmount = (1/UICooldownValue);
   }

    public void GetNotified(float value)
    {
        ChangeCooldownValue(value);
        ChangeCooldownShaderFiller();
    }

}
