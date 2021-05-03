using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FieldGrid : MonoBehaviour
{
    public FieldGridData gridData;
    public FieldGridNodeData nodeData;
    public List<GameObject> nodeList;
    public List<GameObject> spawningNodesList;
    public List<GameObject> fieldUnitsList;

    public int[] randomNodeArray;
    public LayerMask spawningNodeMask;

    public void Init()
    {
        nodeList = new List<GameObject>();
        spawningNodesList = new List<GameObject>();
    }

    public void CreateGrid()
    {
        int nodeNumber = -1;
        for (int y = 0; y < gridData.ySize; y++)
        {
            for (int x = 0; x < gridData.xSize; x++)
            {
                nodeNumber += 1;
                var xPos = transform.position.x + gridData.startingPoint.x + (x * nodeData.width);
                var yPos = transform.position.y - gridData.startingPoint.y + (y * nodeData.width);
                var node = Instantiate(nodeData.nodeVisualizationGO, new Vector3(xPos, 0.0f, yPos), Quaternion.identity);
                node.name = "GridNode_" + nodeNumber;
                node.GetComponent<FieldGridNode>().nodeID = nodeNumber;
                node.transform.SetParent(gameObject.transform);
                nodeList.Add(node);
                if(x == 0)
                {
                    spawningNodesList.Add(node);
                }
                else if(x < 5 || x > 6)
                {
                    //instance.GetComponent<MeshRenderer>().material = nodeData.playableMaterial;
                }
                else
                {
                    node.GetComponent<MeshRenderer>().material = nodeData.playableMaterial;
                }
            }
        }
    }

    public int ChooseRandomNode()
    {
        var spawningListLength = new int[spawningNodesList.Count - 1];
        randomNodeArray = new int[spawningListLength.Length];
        for (int i = 0; i < spawningListLength.Length; i++)
        {
            if(spawningNodesList[i].GetComponent<FieldGridNode>().unitStationed == null)
            {
                randomNodeArray[i] = spawningNodesList[i].GetComponent<FieldGridNode>().nodeID;
            }
        }
        var randomNumber = Random.Range(0, randomNodeArray.Length);
        return randomNodeArray[randomNumber];
    }

    public void HighLightSpawningNodes()
    {
        foreach(GameObject go in spawningNodesList)
        {
            go.layer = 9;
            go.GetComponent<MeshRenderer>().material = nodeData.highlightMaterial;
        }
    }

    public bool AreUnitsNotOnTheBoard()
    {
        bool condition;
        foreach(GameObject go in fieldUnitsList)
        {
            if(go.GetComponent<FieldGridNode>().unitStationed != null)
            {
                fieldUnitsList.Add(go);
            }
        }
        if(fieldUnitsList.Count > 0)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }

    public void Start()
    {
        CreateGrid();
        ChooseRandomNode();
        HighLightSpawningNodes();
    }
}
