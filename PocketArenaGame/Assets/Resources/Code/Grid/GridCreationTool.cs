// ButtonWithParametersExamplesComponent.cs
using Sirenix.OdinInspector;
using UnityEngine;
using System;
using System.Collections.Generic;

public class GridCreationTool : MonoBehaviour
{
    public Vector3 gridOriginPosition;
    public GameObject gridParentObject;
    public FieldGridData gridData;
    public FieldGridNodeData nodeData;

    [Button]
    public void CreateGrid()
    {
        var grid = FindObjectOfType<FieldGrid>();
        grid.nodeCoordinatesDictionary = new Dictionary<Vector2, GameObject>();
        grid.nodeList = new List<GameObject>();
        for (int y = 0; y < gridData.ySize; y++)
        {
            for (int x = 0; x < gridData.xSize; x++)
            {
                var xPos = transform.position.x + (x * nodeData.width);
                var yPos = transform.position.y + (y * nodeData.width);
                var node = Instantiate(nodeData.nodeVisualizationGO, new Vector3(xPos, 0.0f, yPos), Quaternion.identity);
                node.GetComponent<FieldGridNode>().coordinates = new Vector2(x, y);
                node.transform.SetParent(gameObject.transform);
                grid.nodeList.Add(node);
                node.tag = "DefaultNode";
                if (x == 0)
                {
                    node.tag = "SpawnNode";
                    node.GetComponent<MeshRenderer>().material = nodeData.playerANodeMat;
                }
                else if (x > 0 && x < 5)
                {
                    node.tag = "DefaultNode";
                    node.GetComponent<MeshRenderer>().material = nodeData.playerANodeMat;
                }
                else if (x == gridData.xSize - 1)
                {
                    node.tag = "SpawnNode";
                    node.GetComponent<MeshRenderer>().material = nodeData.playerBNodeMat;
                }
                else if (x > 6 && x < gridData.xSize - 1)
                {
                    node.tag = "DefaultNode";
                    node.GetComponent<MeshRenderer>().material = nodeData.playerBNodeMat;
                }
                else if (x == (gridData.xSize / 2) - 1 || x == (gridData.xSize / 2))
                {
                    node.tag = "BorderNode";
                    node.GetComponent<MeshRenderer>().material = nodeData.borderNodeMat;
                }
            }
        }
    }


    [Button]
    public void AssignNodesToEachTeam()
    {
        var grid = FindObjectOfType<FieldGrid>();
        foreach (GameObject node in grid.nodeList)
        {
            if (node.GetComponent<FieldGridNode>().coordinates.x < 6)
            {
                node.GetComponent<FieldGridNode>().nodeTeam = PlayerTeam.TeamA;
            }
            else
            {
                node.GetComponent<FieldGridNode>().nodeTeam = PlayerTeam.TeamB;
            }
        }
    }
}