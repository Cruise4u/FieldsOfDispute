using System;
using UnityEngine;

public class GridMain
{
    public int xSize;
    public int ySize;
    public static GridNode[,] nodes;

    public void CreateGrid()
    {
        nodes = new GridNode[xSize, ySize];
        for (int y = 0; y < ySize; y++)
        {

            for (int x = 0; x < xSize; x++)
            {
                nodes[x, y] = new GridNode(x, y);

            }
        }

    }





}

public class GridNode
{
    public GameObject unitStationed;
    private int xPos;
    private int yPos;

    public GridNode(int xPos, int yPos)
    {
        this.xPos = xPos;
        this.yPos = yPos;
    }






}