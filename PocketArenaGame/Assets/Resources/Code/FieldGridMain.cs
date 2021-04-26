using System;
using UnityEngine;

public class FieldGridMain : MonoBehaviour
{
    public FieldNodeData nodeData;
    public int xSize;
    public int ySize;
    public Vector2 startingPoint;
    public static FieldGridNode[,] nodes;

    public void CreateGrid()
    {
        nodes = new FieldGridNode[xSize, ySize];
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                var xPos = transform.position.x + startingPoint.x + (x * nodeData.width);
                var yPos = transform.position.y - startingPoint.y + (y * nodeData.width);
                nodes[x, y] = new FieldGridNode(xPos, yPos);
                var instance = Instantiate(nodeData.nodeVisualizationGO, new Vector3(xPos, 0.0f, yPos), Quaternion.identity);
                instance.transform.SetParent(transform);
                if (x < 5 || x > 10)
                {
                    instance.GetComponent<MeshRenderer>().material = nodeData.playableMaterial;
                }
                else
                {
                    instance.GetComponent<MeshRenderer>().material = nodeData.nonplayableMaterial;
                }
            }
        }
    }

    public void Start()
    {
        CreateGrid();
    }
}

public class FieldGridNode
{
    public GameObject nodeGO;
    private float xPos;
    private float yPos;

    public FieldGridNode(float xPos, float yPos)
    {
        this.xPos = xPos;
        this.yPos = yPos;
    }



}