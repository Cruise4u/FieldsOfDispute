using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FieldGrid : MonoBehaviour
{
    public FieldGridData gridData;
    public FieldGridNodeData nodeData;
    public List<GameObject> nodeList;
    public List<FieldGridNode> spawningNodeList;
    public Dictionary<Vector2, GameObject> nodeCoordinatesDictionary;

    public void AddEntriesToDictionary()
    {
        nodeCoordinatesDictionary = new Dictionary<Vector2, GameObject>();
        for (int i = 0; i < nodeList.Count; i++)
        {
            nodeCoordinatesDictionary.Add(nodeList[i].GetComponent<FieldGridNode>().coordinates, nodeList[i]);
        }
        foreach(GameObject nodeGO in nodeList)
        {
            if(nodeGO.GetComponent<FieldGridNode>().coordinates.x == 11)
            {
                spawningNodeList.Add(nodeGO.GetComponent<FieldGridNode>());
            }
        }
    }

    public void Start()
    {
        AddEntriesToDictionary();
    }
}
