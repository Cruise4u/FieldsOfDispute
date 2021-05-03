// ButtonWithParametersExamplesComponent.cs
using Sirenix.OdinInspector;
using UnityEngine;

public class GridCreationTool : MonoBehaviour
{
    public Vector3 gridOriginPosition;
    public GameObject gridParentObject;

    [Button]
    private void CreateGrid(FieldGridData gridData,FieldGridNodeData nodeData)
    {
        var grid = FindObjectOfType<FieldGrid>();
        int nodeNumber = -1;
        for (int y = 0; y < gridData.ySize; y++)
        {
            for (int x = 0; x < gridData.xSize; x++)
            {
                nodeNumber += 1;
                var xPos = gridOriginPosition.x + (x * nodeData.width);
                var yPos = gridOriginPosition.y + (y * nodeData.width);
                var node = Instantiate(nodeData.nodeVisualizationGO, new Vector3(xPos, 0.0f, yPos), Quaternion.identity);
                node.name = "GridNode_" + nodeNumber;
                node.GetComponent<FieldGridNode>().nodeID = nodeNumber;
                node.transform.SetParent(gridParentObject.transform);
                grid.nodeList.Add(node);
                if (x == 0)
                {
                    grid.spawningNodesList.Add(node);
                }
                else if (x < 5 || x > 6)
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

    [Button]
    private void DeleteGrid()
    {
        var grid = FindObjectOfType<FieldGrid>();
        foreach(GameObject obj in grid.nodeList)
        {
            DestroyImmediate(obj);
            grid.nodeList.Remove(obj);
        }
        foreach(GameObject obj in grid.spawningNodesList)
        {
            DestroyImmediate(obj);
            grid.nodeList.Remove(obj);
        }
    }
}