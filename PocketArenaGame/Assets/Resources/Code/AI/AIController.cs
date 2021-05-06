using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
    public AIOption currentOption;

    public enum AIOption
    {
        Spell,
        Switch,
    }

    public  void ChooseOption()
    {
        int randomOption = Random.Range(0, 1);
        if(randomOption == 0)
        {
            currentOption = AIOption.Spell;
        }
        else
        {
            currentOption = AIOption.Switch;
        }
    }

    public bool CheckIfOptionIsValid()
    {
        bool condition;
        condition = true;
        return condition;
    }

}
