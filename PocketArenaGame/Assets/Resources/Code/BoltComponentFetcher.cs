using System.Collections;
using UnityEngine;
using Bolt;

public class BoltComponentFetcher : MonoBehaviour
{
    public void SetComponentsOnBolt(string variableName,MonoBehaviour monoComponent)
    {
        Variables.Application.Set(variableName, monoComponent);
    }

}