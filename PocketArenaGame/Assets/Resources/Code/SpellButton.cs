using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour,ISpellObserver
{
    public SpellName spellButtonName;
    public float UICooldownValue;
    public GameObject UICooldownFiller;
    public GameObject UICDValue;

    public void ChangeCooldownValue(float cooldown)
    {
        UICDValue.GetComponent<TextMeshProUGUI>().text = (UICooldownValue - cooldown).ToString();
    }

    public void ChangeCooldownShaderFiller()
   {
        UICooldownFiller.GetComponent<Image>().fillAmount = (1/UICooldownValue);
   }

    public void GetNotified(float cooldown)
    {
        ChangeCooldownValue(cooldown);
        ChangeCooldownShaderFiller();
    }

}
