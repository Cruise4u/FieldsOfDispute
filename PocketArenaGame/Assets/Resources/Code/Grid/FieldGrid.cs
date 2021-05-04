using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FieldGrid : MonoBehaviour
{
    public FieldGridData gridData;
    public FieldGridNodeData nodeData;
    public List<GameObject> nodeList;
    public Dictionary<Vector2, GameObject> nodeCoordinatesDictionary;

    public void AddEntriesToDictionary()
    {
        nodeCoordinatesDictionary = new Dictionary<Vector2, GameObject>();
        for (int i = 0; i < nodeList.Count - 1; i++)
        {
            nodeCoordinatesDictionary.Add(nodeList[i].GetComponent<FieldGridNode>().coordinates, nodeList[i]);
        }
    }

    public void Start()
    {
        AddEntriesToDictionary();
    }
}
